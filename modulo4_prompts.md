# Prompts - Módulo 4: Desarrollo Web Full Stack con Blazor Server

---

## 📚 CLASE 1


### 🤖 PROMPT PARA CLAUDE CODE

```
En este proyecto Blazor Server, muéstrame la estructura de carpetas con un árbol de archivos
y explícame brevemente qué hace cada carpeta principal:
Components/, wwwroot/, Program.cs y el archivo .csproj.

Luego lee el archivo Program.cs y explícame qué hacen estos métodos:
- AddRazorComponents()
- AddInteractiveServerComponents()
- MapRazorComponents<App>()

Al final, dame un resumen de qué es Blazor Server en 2-3 líneas.
```


---

## 📚 CLASE 2: Estructura del proyecto y MudBlazor

### 🤖 PROMPT PARA CLAUDE CODE

```
Instala MudBlazor en este proyecto con este comando:
dotnet add package MudBlazor

MudBlazor es una biblioteca de componentes UI premium que implementa Material Design (como shadcn/ui para React o Vuetify para Vue).

Ahora configura MudBlazor:
1. En Program.cs agrega "using MudBlazor.Services;" al inicio y "builder.Services.AddMudServices();" después de AddRazorComponents

2. En Components/App.razor:
   - Agrega los CSS de MudBlazor en el <head>
   - Agrega MudThemeProvider y MudPopoverProvider dentro del <body>
   - Cambia <Routes /> a <Routes @rendermode="InteractiveServer" />
   - Agrega el JS de MudBlazor antes de cerrar </body>

3. En Components/Routes.razor agrega MudDialogProvider y MudSnackbarProvider antes del Router (estos providers necesitan estar en contexto interactivo para funcionar)

4. En Components/_Imports.razor agrega: @using MudBlazor

5. Actualiza Components/Layout/MainLayout.razor con un diseño moderno usando MudLayout que incluya:
   - MudAppBar (barra superior con título "Product Manager")
   - MudDrawer (menú lateral con NavMenu)
   - MudMainContent (contenido principal)
   - Lógica para abrir/cerrar el drawer con un botón hamburguesa

Al final explícame brevemente qué hace cada provider de MudBlazor.
```


---

## 📚 CLASE 3: Componentes, Servicios y DTOs

### 🤖 PROMPT PARA CLAUDE CODE

```
Crea los DTOs y el servicio para consumir la API del Módulo 3.

Primero crea DTOs/ProductDto.cs como un record inmutable con estas propiedades:
- int Id, string Name, decimal Price
- string FormattedPrice => $"${Price:N2}"
- string PriceCategory que use pattern matching: < 50 retorna "Económico", < 200 retorna "Moderado", el resto "Premium"
- MudBlazor.Color CategoryColor que también use pattern matching: < 50 retorna Color.Success, < 200 retorna Color.Info, el resto Color.Secondary

Luego crea DTOs/CreateProductDto.cs y DTOs/UpdateProductDto.cs como classes mutables con propiedades Name y Price (ambas con get; set;).

Ahora crea Services/ProductService.cs usando Primary Constructor que reciba IHttpClientFactory. El servicio debe tener estos métodos async:
- GetAllAsync() que retorne Task<List<ProductDto>> (usa GetFromJsonAsync y retorna [] si es null)
- GetByIdAsync(int id) que retorne Task<ProductDto?>
- CreateAsync(CreateProductDto dto) que retorne Task<ProductDto?> usando PostAsJsonAsync
- UpdateAsync(int id, UpdateProductDto dto) que retorne Task<bool> usando PutAsJsonAsync
- DeleteAsync(int id) que retorne Task<bool> usando DeleteAsync

Finalmente configura en Program.cs:
- Agrega builder.Services.AddHttpClient("ProductAPI", client => client.BaseAddress = new Uri("http://localhost:5023"))
- Agrega builder.Services.AddScoped<ProductService>()

Incluye comentarios XML explicando por qué ProductDto es record y los otros son class.
```

---

## 📚 CLASE 4: Formularios y Validación con MudBlazor

### 🤖 PROMPT PARA CLAUDE CODE

```
Crea Components/Pages/CreateProduct.razor para agregar nuevos productos.

Configura la página con @page "/products/create", @rendermode InteractiveServer e inyecta ProductService, NavigationManager e ISnackbar.

El diseño debe tener un título "Crear Producto" con MudText Typo.h3 y todo envuelto en un MudCard con Elevation="3", Class="pa-4" y MaxWidth="600px".

Dentro del card crea un MudForm con @ref="_form" y @bind-IsValid="_isValid" que contenga:
- MudTextField para Name con @bind-Value="dto.Name", Label="Nombre del Producto", Variant="Variant.Outlined", Required="true" y Placeholder="Ej: Laptop Dell XPS 13"
- MudNumericField para Price con @bind-Value="dto.Price", Label="Precio", Variant="Variant.Outlined", Required="true", Min="0.01m", Step="0.01m", Format="N2", Adornment="Adornment.Start" y AdornmentText="$"

Agrega botones en MudCardActions: "Cancelar" (Variant.Text) que llame Cancel() y "Guardar" (Variant.Filled, Color.Primary) que llame Save() y esté deshabilitado si el formulario es inválido o está guardando.

En el bloque @code define las variables _form, _isValid, _saving y dto (CreateProductDto).

El método Save() debe poner _saving en true, llamar a ProductService.CreateAsync(dto), mostrar un Snackbar con "Producto creado" si tiene éxito y navegar a "/products", o mostrar "Error al crear" si falla, y finalmente poner _saving en false.

El método Cancel() debe navegar a "/products".
```

---

## 📚 CLASE 5: CRUD Completo (Listar, Editar, Eliminar)

### 🤖 PROMPT PARA CLAUDE CODE

```
Crea Components/Pages/Products.razor con @page "/products", @rendermode InteractiveServer e inyecta ProductService, NavigationManager, IDialogService e ISnackbar.

La página debe mostrar un título "Productos" con MudText Typo.h3 y un botón "Crear Producto" (Color.Primary) que navegue a "/products/create".

Maneja tres estados: si está cargando muestra MudProgressLinear Indeterminate, si la lista está vacía muestra un MudAlert "No hay productos", si hay productos muestra un MudGrid responsive donde cada producto esté en un MudItem xs="12" sm="6" md="4" con un MudCard que contenga MudText para Name (Typo.h5), FormattedPrice (Typo.h4, Color.Primary), un MudChip con CategoryColor y PriceCategory, y botones "Editar" (Variant.Text que navegue a "/products/edit/{id}") y Delete (IconButton).

El método DeleteProduct debe mostrar un MudDialog de confirmación con IDialogService, si confirma llama ProductService.DeleteAsync(id), si tiene éxito remueve el producto de la lista y muestra Snackbar "Eliminado".

En OnInitializedAsync carga los productos con ProductService.GetAllAsync().

Ahora crea Components/Pages/EditProduct.razor similar a CreateProduct pero con @page "/products/edit/{Id:int}", un [Parameter] public int Id, y en OnInitializedAsync carga el producto con GetByIdAsync(Id), si no existe muestra MudAlert error, si existe carga los datos en dto (UpdateProductDto). El método Save() debe llamar UpdateAsync en lugar de CreateAsync.

Finalmente actualiza Components/Layout/NavMenu.razor agregando MudNavLink a "/" (Home con Icon: Icons.Material.Filled.Home) y a "/products" (Productos con Icon: Icons.Material.Filled.ShoppingCart).
```

---

## 📚 CLASE 6: Integración Final y Responsive Design

### 🤖 PROMPT PARA CLAUDE CODE

```
Crea Components/Pages/Home.razor con @page "/" e inyecta ProductService.

La página debe tener un título "Bienvenido a Product Manager" con MudText Typo.h3, un MudAlert Severity.Info que diga "Aplicación Blazor Server con .NET 10 que consume API REST", y un MudCard con estadísticas que en OnInitializedAsync cargue los productos y muestre el total con MudText Typo.h4 junto a un icono Icons.Material.Filled.Inventory. Agrega un MudButton Color.Primary que navegue a "/products".

Mejora Components/Layout/MainLayout.razor para que el drawer sea responsive con Breakpoint="Breakpoint.Md" (se oculta en móvil) y ClipMode="DrawerClipMode.Always". El botón hamburguesa debe funcionar para abrir/cerrar el drawer, y en móvil el drawer debe estar cerrado por defecto.

Verifica que Components/Pages/Products.razor tenga el grid responsive correcto con MudItem xs="12" sm="6" md="4" (1 columna en móvil, 2 en tablet, 3 en desktop) y que las cards tengan altura igual con Class="d-flex flex-column" Style="height: 100%".

Explícame cómo funciona el flujo completo: navegar de Home a Products, crear un producto, editarlo y eliminarlo.
```

## 🚀 Recursos de Aprendizaje

**Documentación oficial:**
- [Blazor .NET 10](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0)
- [MudBlazor Components](https://mudblazor.com/components)
- [C# 14 Features](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14)

---

**dheeyi@gmail.com | .NET 10 | C# 14 | Claude Code**

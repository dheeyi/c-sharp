using ProductsWebApi.Data;
using ProductsWebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// var products = new List<Product>
// {
//     new(1, "Laptop Dell XPS 13", 1299.99m),
//     new(2, "Mouse Logitech MX Master", 99.99m),
//     new(3, "Teclado Mecánico Keychron", 89.99m)
// };

// app.MapGet("/api/products", () =>
//     {
//         return Results.Ok(products);
//     })
//     .WithName("GetProducts")
//     .WithTags("Products");
//
// app.MapGet("/api/products/{id:int}", (int id) =>
//     {
//         var product = products.FirstOrDefault(p => p.Id == id);
//     
//         if (product is null)
//         {
//             return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
//         }
//     
//         return Results.Ok(product);
//     })
//     .WithName("GetProductById")
//     .WithTags("Products");
//
// app.MapPost("/api/products", (Product product) =>
//     {
//         product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
//
//         products.Add(product); // simulando al insert en la DB
//         return Results.Created($"/api/products/{product.Id}", product);
//     })
//     .WithName("CreateProduct")
//     .WithTags("Products");
//
// app.MapPut("/api/products/{id:int}", (int id, Product updatedProduct) =>
//     {
//         var product = products.FirstOrDefault(p => p.Id == id);
//
//         if (product is null)
//         {
//             return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
//         }
//
//         product.Name = updatedProduct.Name;
//         product.Price = updatedProduct.Price;
//
//         return Results.Ok(product);
//     })
//     .WithName("UpdateProduct");
//
// // ejericio DELETE
// app.MapDelete("/api/products/{id:int}", (int id) =>
//     {
//         var product = products.FirstOrDefault(p => p.Id == id);
//
//         if (product is null)
//         {
//             return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
//         }
//
//         products.Remove(product);
//
//         return Results.NoContent();
//     })
//     .WithName("DeleteProduct");

// app.MapGet("/api/products", () =>
// {
//     var productsDto = products.Select(p => new ProductDto(
//         p.Id,
//         p.Name,
//         p.Price
//     ));
//     
//     return Results.Ok(productsDto);
// });
//
// app.MapPost("/api/products", (CreateProductDto dto) =>
// {
//     var newId = products.Any() ? products.Max(p => p.Id) + 1 : 1;
//
//     var product = new Product(newId, dto.Name, dto.Price)
//     {
//         CreatedAt = DateTime.UtcNow 
//     };
//     
//     products.Add(product);
//     
//     var productDto = new ProductDto(product.Id, product.Name, product.Price);
//     
//     return Results.Created($"/api/products/{product.Id}", productDto);
// });

app.MapProductEndpoint();

app.Run();


namespace ProductsWeb.DTOs;

/// <summary>
/// DTO mutable para crear nuevos productos.
///
/// Usamos class en lugar de record porque:
/// - Se usa con formularios que requieren two-way binding (@bind)
/// - Las propiedades deben ser modificables mientras el usuario escribe
/// - MudBlazor forms necesitan setters públicos para funcionar
/// </summary>
public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

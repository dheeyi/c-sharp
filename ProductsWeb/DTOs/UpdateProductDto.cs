namespace ProductsWeb.DTOs;

/// <summary>
/// DTO mutable para actualizar productos existentes.
///
/// Usamos class en lugar de record porque:
/// - Se usa con formularios que requieren two-way binding (@bind)
/// - Las propiedades deben ser modificables mientras el usuario escribe
/// - MudBlazor forms necesitan setters públicos para funcionar
/// </summary>
public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

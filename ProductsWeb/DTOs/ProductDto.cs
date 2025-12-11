using MudBlazor;

namespace ProductsWeb.DTOs;

/// <summary>
/// DTO inmutable para representar productos de la API.
///
/// Usamos record en lugar de class porque:
/// - Los datos vienen de la API y no deben modificarse después de deserializar
/// - Records proveen igualdad por valor (útil para comparar productos)
/// - Sintaxis concisa con propiedades init-only
/// - Inmutabilidad garantiza thread-safety y previene bugs por mutación accidental
/// </summary>
public record ProductDto(int Id, string Name, decimal Price)
{
    /// <summary>
    /// Precio formateado con símbolo de moneda y 2 decimales.
    /// </summary>
    public string FormattedPrice => $"${Price:N2}";

    /// <summary>
    /// Categoría basada en el precio usando pattern matching.
    /// </summary>
    public string PriceCategory => Price switch
    {
        < 50 => "Económico",
        < 200 => "Moderado",
        _ => "Premium"
    };

    /// <summary>
    /// Color de MudBlazor según la categoría de precio.
    /// </summary>
    public Color CategoryColor => Price switch
    {
        < 50 => Color.Success,
        < 200 => Color.Info,
        _ => Color.Secondary
    };
}

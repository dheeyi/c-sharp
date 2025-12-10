using System.ComponentModel.DataAnnotations;

namespace ProductsWebApi.DTOs;

public record UpdateProductDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; init; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; init; }
}

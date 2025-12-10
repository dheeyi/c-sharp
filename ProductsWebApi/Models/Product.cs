namespace ProductsWebApi.Models;

public class Product(int id, string name, decimal price)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    
    // campos internos (no exponer en la API)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt  { get; set; }
    
    //DTOs (exponer solo lo necesario) = Data transfer object
    // public record ProductDto(
    //     int Id,
    //     string Name,
    //     decimal Price
    // );
}

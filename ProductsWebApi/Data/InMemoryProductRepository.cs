using System.Collections.Concurrent;
using ProductsWebApi.Data;
using ProductsWebApi.Models;

namespace ProductsWebApi.Data;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<int, Product> _products = new();
    private int _nextId = 1;

    public InMemoryProductRepository()
    {
        Add(new Product(0, "Laptop Dell XPS 13", 1299.99m));
        Add(new Product(0, "Mouse Logitech MX Master", 99.99m));
        Add(new Product(0, "Teclado Mecánico Keychron", 89.99m));
    }
    
    public IEnumerable<Product> GetAll()
    {
        return _products.Values.OrderBy(p => p.Name);
    }

    public Product? GetById(int id)
    {
        _products.TryGetValue(id, out var product);
        return product;
    }
    
    public Product Add(Product product)
    {
        product.Id = Interlocked.Increment(ref _nextId);
        product.CreatedAt = DateTime.UtcNow;
        _products.TryAdd(product.Id, product);
        return product;
    }
    
    public bool Update(Product product)
    {
        if (!_products.ContainsKey(product.Id))
            return false;

        product.UpdatedAt = DateTime.UtcNow;
        _products[product.Id] = product;
        return true;
    }
    
    public bool Delete(int id)
    {
        return _products.TryRemove(id, out _);
    }
}

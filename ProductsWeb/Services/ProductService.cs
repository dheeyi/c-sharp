using System.Net.Http.Json;
using ProductsWeb.DTOs;

namespace ProductsWeb.Services;

/// <summary>
/// Servicio para consumir la API de productos.
/// Usa Primary Constructor para inyectar IHttpClientFactory.
/// </summary>
public class ProductService(IHttpClientFactory httpClientFactory)
{
    private HttpClient CreateClient() => httpClientFactory.CreateClient("ProductAPI");

    /// <summary>
    /// Obtiene todos los productos de la API.
    /// </summary>
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var client = CreateClient();
        var products = await client.GetFromJsonAsync<List<ProductDto>>("api/products");
        return products ?? [];
    }

    /// <summary>
    /// Obtiene un producto por su ID.
    /// </summary>
    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var client = CreateClient();
        return await client.GetFromJsonAsync<ProductDto>($"api/products/{id}");
    }

    /// <summary>
    /// Crea un nuevo producto.
    /// </summary>
    public async Task<ProductDto?> CreateAsync(CreateProductDto dto)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("api/products", dto);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        return null;
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var client = CreateClient();
        var response = await client.PutAsJsonAsync($"api/products/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    /// <summary>
    /// Elimina un producto por su ID.
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var client = CreateClient();
        var response = await client.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }
}

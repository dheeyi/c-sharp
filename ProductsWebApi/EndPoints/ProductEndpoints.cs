using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Data;
using ProductsWebApi.DTOs;
using ProductsWebApi.Models;

namespace ProductsWebApi.EndPoints;

public static class ProductEndPoints
{
    public static void MapProductEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products")
            .WithTags("Products");

        // GET /api/products - Obtener todos los productos
        group.MapGet("/", GetAllProducts)
            .WithName("GetAllProducts")
            .WithSummary("Obtiene todos los productos activos")
            .WithDescription("Retorna una lista de todos los productos disponibles en el catálogo")
            .Produces<IEnumerable<ProductDto>>(StatusCodes.Status200OK);

        // GET /api/products/{id} - Obtener producto por ID
        group.MapGet("/{id:int}", GetProductById)
            .WithName("GetProductById")
            .WithSummary("Obtiene un producto por su ID")
            .Produces<ProductDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        // POST /api/products - Crear nuevo producto
        group.MapPost("/", CreateProduct)
            .WithName("CreateProduct")
            .WithSummary("Crea un nuevo producto")
            .Produces<ProductDto>(StatusCodes.Status201Created)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest);

        // PUT /api/products/{id} - Actualizar producto
        group.MapPut("/{id:int}", UpdateProduct)
            .WithName("UpdateProduct")
            .WithSummary("Actualiza un producto existente")
            .Produces<ProductDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest);

        // DELETE /api/products/{id} - Eliminar producto
        group.MapDelete("/{id:int}", DeleteProduct)
            .WithName("DeleteProduct")
            .WithSummary("Elimina un producto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static IResult GetAllProducts(IProductRepository repository)
    {
        var products = repository.GetAll();

        var productsDto = products.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Price
        ));

        return Results.Ok(productsDto);
    }

    private static IResult GetProductById(int id, IProductRepository repository)
    {
        var product = repository.GetById(id);

        if (product is null)
        {
            return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
        }

        var productDto = new ProductDto(
            product.Id,
            product.Name,
            product.Price
        );

        return Results.Ok(productDto);
    }

    private static IResult CreateProduct(
        CreateProductDto dto,
        IProductRepository repository)
    {
        var product = new Product(0, dto.Name, dto.Price);

        var createdProduct = repository.Add(product);

        var productDto = new ProductDto(
            createdProduct.Id,
            createdProduct.Name,
            createdProduct.Price
        );

        return Results.Created($"/api/products/{productDto.Id}", productDto);
    }

    private static IResult UpdateProduct(
        int id,
        UpdateProductDto dto,
        IProductRepository repository)
    {
        var existingProduct = repository.GetById(id);
        if (existingProduct is null)
        {
            return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
        }

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;

        repository.Update(existingProduct);

        var productDto = new ProductDto(
            existingProduct.Id,
            existingProduct.Name,
            existingProduct.Price
        );

        return Results.Ok(productDto);
    }

    private static IResult DeleteProduct(int id, IProductRepository repository)
    {
        var deleted = repository.Delete(id);

        if (!deleted)
        {
            return Results.NotFound(new { message = $"Producto con ID {id} no encontrado" });
        }

        return Results.NoContent();
    }
}
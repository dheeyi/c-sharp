namespace AsyncAwait;

public class TiendaOnline
{
    //LINQ
    private readonly Dictionary<string, int> _inventario = new()
    {
        ["Laptop"] = 5,
        ["Mouse"] = 20,
        ["Teclado"] = 15,
        ["Monitor"] = 8
    };
    
    public async Task<bool> ConsultarStockAsync(string producto, int cantidad)
    {
        Console.WriteLine($"Consultando stock de {producto}...");
        
        await Task.Delay(1000); 
        
        if (!_inventario.ContainsKey(producto))
            return false;
        
        var disponible = _inventario[producto];
        Console.WriteLine($"Stock encontrado: {disponible} unidades");
        
        return true;
    }
    
    public async Task<string> ProcesarPagoAsync(string tarjeta, decimal monto)
    {
        Console.WriteLine($"Procesando pago de ${monto:F2}...");
        
        await Task.Delay(2000);
        
        var codigoTransaccion = $"TXN-{DateTime.Now.Ticks % 100000}";
        Console.WriteLine($"Pago aprobado: {codigoTransaccion}");
        
        return codigoTransaccion;
    }
    
    public async Task<string> EnviarPedidoAsync(string direccion)
    {
        Console.WriteLine($"Preparando envío a {direccion}...");
        
        await Task.Delay(1500);
        
        var tracking = $"TRACK-{Guid.NewGuid().ToString()[..8].ToUpper()}";
        Console.WriteLine($"Envío programado: {tracking}");
        
        return tracking;
    }
    
    public async Task ActualizarInventarioAsync(string producto, int cantidad)
    {
        Console.WriteLine($"Actualizando inventario de {producto}...");
        await Task.Delay(500);
        
        if (_inventario.ContainsKey(producto))
        {
            _inventario[producto] -= cantidad;
            Console.WriteLine($"Inventario actualizado: {_inventario[producto]} unidades restantes");
        }
    }
    
    public async Task<List<string>> ConsultarMultiplesProductosAsync(List<string> productos)
    {
        Console.WriteLine($"\nConsultando {productos.Count} productos en paralelo...");
        
        var tareas = productos.Select(p => ConsultarDisponibilidadAsync(p));
        var resultados = await Task.WhenAll(tareas);
        
        return resultados.ToList();
    }
    
    private async Task<string> ConsultarDisponibilidadAsync(string producto)
    {
        await Task.Delay(500);
        var stock = _inventario.GetValueOrDefault(producto, 0);
        return $"{producto}: {stock} unidades";
    }
    
    public async Task<string> ObtenerProveedorMasRapidoAsync()
    {
        var proveedores = new[]
        {
            SimularProveedorAsync("Proveedor A", 1000),
            SimularProveedorAsync("Proveedor B", 500),
            SimularProveedorAsync("Proveedor C", 1500)
        };

        var tareaCompletada = await Task.WhenAny(proveedores);
        return await tareaCompletada;
    }
    
    private async Task<string> SimularProveedorAsync(string nombre, int delay)
    {
        await Task.Delay(delay);
        return $"{nombre} respondió en {delay}ms";
    }
}
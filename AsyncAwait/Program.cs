using AsyncAwait;

var tienda = new TiendaOnline();

await ProcesarPedidoExitoso();
await ConsultarProductosEnParalelo();
await DemostrarTaskWhenAny();

await DemostrarExcepciones();

async Task ProcesarPedidoExitoso()
{
    Console.WriteLine("Caso: Pedido Exitoso (async/await secuencial)\n");

    var pedido = new Pedido("Laptop", 2, "1234567890123456", 999.99m, "Av. Principal 123, Lima");

    try
    {
        await tienda.ConsultarStockAsync(pedido.Producto, pedido.Cantidad);
        pedido.CodigoTransaccion = await tienda.ProcesarPagoAsync(pedido.Tarjeta, pedido.PrecioTotal);
        pedido.NumeroSeguimiento = await tienda.EnviarPedidoAsync(pedido.Direccion);
        await tienda.ActualizarInventarioAsync(pedido.Producto, pedido.Cantidad);

        pedido.Completado = true;
        Console.WriteLine($"\n{pedido}");
        Console.WriteLine($"Código: {pedido.CodigoTransaccion} | Tracking: {pedido.NumeroSeguimiento}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

async Task ConsultarProductosEnParalelo()
{
    Console.WriteLine("\nCaso: Task.WhenAll (consultas en paralelo)\n");

    var productos = new List<string> { "Laptop", "Mouse", "Teclado", "Monitor" };
    var inicio = DateTime.Now;
    var resultados = await tienda.ConsultarMultiplesProductosAsync(productos);
    var duracion = (DateTime.Now - inicio).TotalSeconds;

    Console.WriteLine($"Completado en {duracion:F1}s (secuencial: 2s)");
    resultados.ForEach(r => Console.WriteLine($"  {r}"));
}

async Task DemostrarTaskWhenAny()
{
    Console.WriteLine("\nCaso: Task.WhenAny (primera tarea completada)\n");

    var resultado = await tienda.ObtenerProveedorMasRapidoAsync();
    Console.WriteLine($"{resultado}");
}

async Task DemostrarExcepciones()
{
    // Try-catch-finally
    Console.WriteLine("Try-Catch-Finally:\n");
    var pedido = new Pedido("Mouse", 100, "1234567890123456", 29.99m, "Calle Falsa 123");

    try
    {
        Console.WriteLine("try: Intentando procesar pedido...");
        await tienda.ConsultarStockAsync(pedido.Producto, pedido.Cantidad);
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"catch:{ex.Message}");
        Console.WriteLine($"Datos: Disponible={ex.Disponible}, Solicitado={ex.Solicitado}");
    }
    finally
    {
        Console.WriteLine("finally: SIEMPRE se ejecuta (liberar recursos, logs, etc.)\n");
    }

    Console.WriteLine("Múltiples Catch + Excepciones Personalizadas:\n");

    var tests = new (string nombre, Func<Task> accion)[]
    {
        ("Stock insuficiente", () => tienda.ConsultarStockAsync("Laptop", 999)),
        ("Pago rechazado", () => tienda.ProcesarPagoAsync("123", 50000m)),
        ("Envío fallido", () => tienda.EnviarPedidoAsync("ab"))
    };

    foreach (var (nombre, accion) in tests)
    {
        try
        {
            await accion();
        }
        catch (StockInsuficienteException ex)
        {
            Console.WriteLine($"{ex.GetType().Name}: {ex.Producto} (Disp: {ex.Disponible})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }

    Console.WriteLine("\nExcepciones personalizadas: errores específicos con propiedades adicionales");
}
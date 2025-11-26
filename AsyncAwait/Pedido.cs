namespace AsyncAwait;

public class Pedido(string producto, int cantidad, string tarjeta, decimal precio, string direccion)
{
    public string Producto { get; } = producto;
    public int Cantidad { get; } = cantidad;
    public string Tarjeta { get; } = tarjeta;
    public decimal PrecioTotal { get; } = precio * cantidad;
    
    public string Direccion
    {
        get => field;
        set => field = string.IsNullOrWhiteSpace(value) ? "Dirección no especificada" : value.Trim();
    } = direccion;
    
    public string? CodigoTransaccion { get; set; }
    public string? NumeroSeguimiento { get; set; }
    public bool Completado { get; set; }
    
    public override string ToString() 
        => $"Pedido: {Cantidad}x {Producto} | Total: ${PrecioTotal:F2} | Estado: {(Completado ? "Completado" : "Procesando")}";
}
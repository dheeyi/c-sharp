namespace AsyncAwait;

public class StockInsuficienteException(string producto, int disponible, int solicitado)
    : Exception($"Stock insuficiente de '{producto}'. Disponible: {disponible}, Solicitado: {solicitado}")
{
    public string Producto { get; } = producto;
    public int Disponible { get; } = disponible;
    public int Solicitado { get; } = solicitado;
    
    public class PagoRechazadoException(string tarjeta, string motivo) 
        : Exception($"Pago rechazado. Tarjeta: {tarjeta}, Motivo: {motivo}")
    {
        public string Tarjeta { get; } = tarjeta;
        public string Motivo { get; } = motivo;
    }
    
    public class EnvioFallidoException(string direccion) 
        : Exception($"No se puede enviar a: {direccion}")
    {
        public string Direccion { get; } = direccion;
    }
}
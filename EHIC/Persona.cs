namespace EHIC;

public class Persona(string nombre, string apellido, int edad)
{
    //private
    private string _id = Guid.NewGuid().ToString()[..8];
    
    //public
    public string Nombre { get; set; } = nombre;
    public string Apellido { get; set; } = apellido;
    
    //protected
    protected int Edad { get; set; } = edad;
    
    //internal
    internal string CodigoInterno { get; set; } = $"INT-{DateTime.Now.Ticks % 10000}";
    
    public string Id => _id;
    
    //virtual
    public virtual string ObtenerInfo() => $"{Nombre} {Apellido} (ID: {Id})";
    
    //protected
    protected string ObtenerEdad() => $"{Edad} años";
}

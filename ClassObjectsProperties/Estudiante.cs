namespace ClassObjectsProperties;

public class Estudiante(int id, string nombres, string apellidos)
{
    public int Id { get; set; } = id;
    public string Nombres { get; set; } = nombres.Trim();
    public string Apellidos { get; set; } = apellidos.Trim();
    
    // crear una propieda Email que pord efecto tenga esto
    // nombres + apellidos + @my-university.com
    public string Email
    {
        get => string.IsNullOrWhiteSpace(field)
            ? $"{Nombres.ToLower()}.{Apellidos.ToLower()}@mi-universidad.com"
            : field;
        set => field = string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : value.Trim().ToLower();
    } = string.Empty;

    public List<string> Cursos { get; } = [];

    public void InscribirCurso(string curso)
    {
        Cursos.Add(curso);
        Console.WriteLine($"Curso '{curso}' añadido a est: {Nombres}");
    }
    
    public string ObtenerInfo() => $"Estudiante: (ID: {Id}) {Nombres} {Apellidos}";
    
    public string ObtenerCursos() => $"Cursos: {string.Join(", ", Cursos)}";

    // public string ObtenerInfo2()
    // {
    //     return $"Estudiante: (ID: {Id}) {Nombres} {Apellidos}";
    // }
}

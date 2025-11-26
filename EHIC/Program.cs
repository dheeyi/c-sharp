// See https://aka.ms/new-console-template for more information

using EHIC;

Console.WriteLine("Hello, World!");


var persona = new Persona("Juan", "Perez", 30);
Console.WriteLine($"Public: {persona.Nombre}");
Console.WriteLine($"Private con getter público: {persona.Id}");
Console.WriteLine($"Internal: {persona.CodigoInterno}");
Console.WriteLine("persona._id (private) y persona.Edad (protected) - NO accesibles\n");


var estudiante1 = new Estudiante("Maria", "Garcia", 20, "Ingeniería");
var estudiante2 = new Estudiante("Carlos", "Lopez", 22, "Medicina");
var estudiante3 = new Estudiante("Ana", "Martinez", 21, "Ingeniería");

estudiante1.AgregarCalificacion(18);
estudiante1.AgregarCalificacion(16);
estudiante1.AgregarCalificacion(19);
estudiante2.AgregarCalificacion(12);
estudiante2.AgregarCalificacion(13);
estudiante3.AgregarCalificacion(15);
estudiante3.AgregarCalificacion(17);

Console.WriteLine($"{estudiante1.ObtenerInfo()}");
Console.WriteLine($"{estudiante2.ObtenerInfo()}\n");
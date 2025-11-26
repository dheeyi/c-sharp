// See https://aka.ms/new-console-template for more information

using ClassObjectsProperties;

Console.WriteLine("Hello, World!");

// Estudiante est1 = new Estudiante(111, "William", "Barra");
var est1 = new Estudiante(111, "William", "Barra");
var est2 = new Estudiante(222, "Carla", "Monroy");

est1.InscribirCurso("Matematicas");
est1.InscribirCurso("Programacion");
est2.InscribirCurso("Fisica");

Console.WriteLine($"{est1.ObtenerInfo()} {est1.ObtenerCursos()}");
Console.WriteLine($"{est2.ObtenerInfo()} {est2.ObtenerCursos()}");

Console.WriteLine($"{est1.Nombres}: {est1.Email}\n");
est1.Email = "my-email@gmail.com";

Console.WriteLine($"{est1.Nombres}: {est1.Email}");


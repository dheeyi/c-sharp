Console.WriteLine("Operadores!");

int a = 10; 
int b = 20;

int c = a + b;

Console.WriteLine($"{a} + {b} = {c}");
Console.WriteLine();

int edad = 25;

bool esIgual = (edad == 25);
bool esDiferente = (edad != 30);
bool esMayor = (edad > 18);

Console.WriteLine($"edad = {edad}");
Console.WriteLine($"edad == 25:  {esIgual}  (Igual a)");
Console.WriteLine($"edad != 30:  {esDiferente}  (Diferente de)");
Console.WriteLine($"edad > 18:   {esMayor}  (Mayor que)");
Console.WriteLine();

bool esEstudiante = true;
bool esMayorDeEdad = false;

bool resultado1 = esEstudiante && esMayorDeEdad;

bool resultado2 = esEstudiante || esMayorDeEdad;

Console.WriteLine($"esEstudiante = {esEstudiante}");
Console.WriteLine($"esMayorDeEdad = {esMayorDeEdad}");

Console.WriteLine($"AND (&&): esEstudiante && esMayorDeEdad = {resultado1}");
Console.WriteLine($"OR  (||): esEstudiante || esMayorDeEdad = {resultado2}");
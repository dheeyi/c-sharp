Console.WriteLine("Precedencia");

int resultado1 = 10 + 5 * 2;

Console.WriteLine("Expresión: 10 + 5 * 2");
Console.WriteLine();
Console.WriteLine("Orden de evaluación:");
Console.WriteLine("Paso 1: 5 * 2 = 10 (Multiplicación tiene mayor precedencia)");
Console.WriteLine("Paso 2: 10 + 10 = 20 (Suma)");
Console.WriteLine();

Console.WriteLine();

int resultado2 = (10 + 5) * 2;
int resultado3 = 10 + (5 * 2);

Console.WriteLine("Expresión 1: (10 + 5) * 2");
Console.WriteLine("Paso 1: (10 + 5) = 15 (Paréntesis fuerza la suma primero)");
Console.WriteLine("Paso 2: 15 * 2 = 30 (Multiplicación)");
Console.WriteLine($"Resultado: {resultado2}");
Console.WriteLine();

Console.WriteLine("Expresión 2: 10 + (5 * 2)");
Console.WriteLine("Paso 1: (5 * 2) = 10 (Paréntesis explícitos)");
Console.WriteLine("Paso 2: 10 + 10 = 20 (Suma)");
Console.WriteLine($" Resultado: {resultado3}");
Console.WriteLine();
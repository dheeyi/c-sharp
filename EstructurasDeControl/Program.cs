Console.WriteLine("Hello, World!");

int edad = 20;
if (edad >= 18)
{
    Console.WriteLine($"Edad {edad}: Mayor de edad\n");
}

int temperatura = 25;
if (temperatura > 30)
{
    Console.WriteLine("Hace calor");
}
else
{
    Console.WriteLine($"Temperatura agradable: {temperatura}°C\n");
}

int numero = 10;
string tipo = numero % 2 == 0 ? "PAR" : "IMPAR";

Console.WriteLine($"Número {numero} es {tipo}");


int dia = 3;
switch (dia)
{
    case 1: Console.WriteLine("Lunes"); break;
    case 2: Console.WriteLine("Martes"); break;
    case 3: Console.WriteLine("Miércoles"); break;
    case 6: Console.WriteLine("Miércoles"); break;
    case 7: Console.WriteLine("Fin de semana!"); break;
    default: Console.WriteLine("Día inválido"); break;
}

string mes = "Junio";
int dias = mes switch
{
    "Enero" or "Marzo" or "Mayo" or "Julio" or "Agosto" or "Octubre" or "Diciembre" => 31,
    "Abril" or "Junio" or "Septiembre" or "Noviembre" => 30,
    "Febrero" => 28,
    _ => 0
};

Console.WriteLine($"\n{mes} tiene {dias} días");

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"{i}");
}

// Ejemplo de While
int contador = 1;
while (contador <= 5)
{
    Console.WriteLine($"Contador: {contador}");
    contador++;
}

int num = 10;
do
{
    Console.Write($"{num} ");
    num++;
} while (num < 5);


int[] numeros = [10, 20, 30, 40, 50];
int suma = 0;

foreach (var n in numeros)
{
    suma += n;
    Console.WriteLine($"+ {n} = {suma}");
}

Console.WriteLine("BREAK vs CONTINUE:");
Console.Write("Con BREAK: ");
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        Console.Write("[BREAK] ");
        break;
    }
    Console.Write($"{i} ");
}

Console.WriteLine();
Console.Write("Con CONTINUE: ");
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        Console.Write("[SKIP] ");
        continue;
    }
    Console.Write($"{i} ");
}

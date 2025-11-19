Saludar();

void Saludar()
{
    Console.WriteLine("¡Hola Mundo!");
}

SaludarPersona("María");

void SaludarPersona(string nombre)
{
    Console.WriteLine($"¡Hola {nombre}!");
}

MostrarInfo("Ana", 25);

void MostrarInfo(string nombre, int edad)
{
    Console.WriteLine($"{nombre} tiene {edad} años");
}

int suma = Sumar(5, 3);
Console.WriteLine($"Suma: 5 + 3 = {suma}");

int Sumar(int a, int b)
{
    return a + b;
}

bool esPar = EsPar(10);
Console.WriteLine($"¿10 es par? {esPar}");

bool EsPar(int numero)
{
    return numero % 2 == 0;
}


int[] numeros = [10, 20, 30, 40, 50];
string[] frutas = ["Manzana", "Plátano", "Naranja", "Uva"];

Console.WriteLine($"Primer número: {numeros[0]}");
Console.WriteLine($"Última fruta: {frutas[1]}");

string[] paises = ["México", "España", "Argentina", "Colombia", "Chile"];

for (int i = 0; i < paises.Length; i++)
{
    Console.WriteLine($"  {i + 1}. {paises[i]}");
}

List<string> nombres = ["Ana", "Carlos", "María"];
nombres.Add("Pedro");
nombres.Add("Laura");
Console.WriteLine($"Lista después de Add: {string.Join(", ", nombres)}");

nombres.Insert(1, "José");
Console.WriteLine($"Después de Insert(1, José): {string.Join(", ", nombres)}");

nombres.Remove("Carlos");
Console.WriteLine($"Después de Remove(Carlos): {string.Join(", ", nombres)}");

List<int> nums = [3, 1, 4, 1, 5, 9, 2, 6];

nums.Sort();
Console.WriteLine($"Ordenado: {string.Join(", ", nums)}");
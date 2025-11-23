using System;
using System.Collections.Generic;

class Program
{
    static List<string> items = new List<string>();

    static void Main()
    {
        Console.WriteLine("=== Sistema CRUD - Gestión de Items ===");
        Console.WriteLine("Funcionalidad: Crear item");

        CreateItem();
    }

    static void CreateItem()
    {
        Console.WriteLine("Ingrese el nombre del item:");
        string item = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(item))
        {
            items.Add(item);
            Console.WriteLine($"Item agregado correctamente: {item}");
        }
        else
        {
            Console.WriteLine("No se puede agregar un item vacío.");
        }
    }
}

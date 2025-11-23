using System;
using System.Collections.Generic;

class Program
{
    static List<string> items = new List<string>();

    static void Main()
    {
        Console.WriteLine("=== Sistema CRUD - Gestión de Items ===");
        Console.WriteLine("1. Crear item");
        Console.WriteLine("2. Listar items");
        Console.WriteLine("Seleccione una opción:");

        string option = Console.ReadLine();

        if (option == "1")
        {
            CreateItem();
        }
        else if (option == "2")
        {
            ListItems();
        }
        else
        {
            Console.WriteLine("Opción no válida");
        }
    }

    static void CreateItem()
    {
        Console.WriteLine("Ingrese el nombre del item:");
        string? item = Console.ReadLine();

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

    static void ListItems()
    {
        Console.WriteLine("=== ITEMS REGISTRADOS ===");

        if (items.Count == 0)
        {
            Console.WriteLine("No existen items aún.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }
    }
}

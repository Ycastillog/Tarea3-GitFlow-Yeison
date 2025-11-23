using System;
using System.Collections.Generic;

class Program
{
    
    static List<string> items = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== Sistema CRUD - Gestión de Items ===");
            Console.WriteLine("1. Crear item");
            Console.WriteLine("2. Listar items");
            Console.WriteLine("3. Actualizar item");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateItem();
                    break;

                case "2":
                    ListItems();
                    break;

                case "3":
                    UpdateItem();
                    break;

                case "0":
                    // Salimos del programa
                    return;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateItem()
    {
        Console.Write("Ingrese el nombre del item: ");
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

    static void UpdateItem()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No hay items para actualizar.");
            return;
        }

        Console.Write("Ingrese el nombre del item a modificar: ");
        string? oldItem = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(oldItem))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        if (!items.Contains(oldItem))
        {
            Console.WriteLine("El item no existe.");
            return;
        }

        Console.Write("Ingrese el nuevo nombre del item: ");
        string? newItem = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newItem))
        {
            Console.WriteLine("El nuevo nombre no puede estar vacío.");
            return;
        }

        int index = items.IndexOf(oldItem);
        items[index] = newItem;

        Console.WriteLine($"Item actualizado correctamente: {newItem}");
    }
}


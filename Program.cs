using System;
using System.Collections.Generic;

class Program
{
    // Lista de items en memoria
    static List<string> items = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== Sistema CRUD - Gestión de Items ===");
            Console.WriteLine("1. Crear item");
            Console.WriteLine("2. Listar items");
            Console.WriteLine("3. Actualizar item");
            Console.WriteLine("4. Eliminar item");
            Console.WriteLine("5. Buscar item");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();
            Console.WriteLine();

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

                case "4":
                    DeleteItem();
                    break;

                case "5":
                    SearchItem();
                    break;

                case "0":
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
        Console.WriteLine("=== CREAR ITEM ===");
        Console.Write("Ingrese el nombre del item: ");
        string? item = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(item))
        {
            string normalized = item.Trim();
            items.Add(normalized);
            Console.WriteLine($"Item agregado correctamente: {normalized}");
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

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
    }

    static void UpdateItem()
    {
        Console.WriteLine("=== ACTUALIZAR ITEM ===");

        if (items.Count == 0)
        {
            Console.WriteLine("No hay items para actualizar.");
            return;
        }

        ListItems();
        Console.WriteLine();
        Console.Write("Ingrese el número del item a actualizar: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int index) || index < 1 || index > items.Count)
        {
            Console.WriteLine("Número de item inválido.");
            return;
        }

        Console.Write("Ingrese el nuevo nombre del item: ");
        string? newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        string trimmedName = newName.Trim();
        string oldName = items[index - 1];
        items[index - 1] = trimmedName;

        Console.WriteLine($"Item actualizado correctamente: '{oldName}' ahora es '{trimmedName}'.");
    }

    static void DeleteItem()
    {
        Console.WriteLine("=== ELIMINAR ITEM ===");

        if (items.Count == 0)
        {
            Console.WriteLine("No hay items para eliminar.");
            return;
        }

        ListItems();
        Console.WriteLine();
        Console.Write("Ingrese el número del item a eliminar: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int index) || index < 1 || index > items.Count)
        {
            Console.WriteLine("Número de item inválido.");
            return;
        }

        string removed = items[index - 1];
        items.RemoveAt(index - 1);

        Console.WriteLine($"Item eliminado correctamente: {removed}");
    }

    static void SearchItem()
    {
        Console.WriteLine("=== BUSCAR ITEMS ===");

        if (items.Count == 0)
        {
            Console.WriteLine("No hay items para buscar.");
            return;
        }

        Console.Write("Ingrese texto a buscar: ");
        string? term = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(term))
        {
            Console.WriteLine("El término de búsqueda no puede estar vacío.");
            return;
        }

        term = term.Trim();
        List<string> results = items.FindAll(
            item => item.Contains(term, StringComparison.OrdinalIgnoreCase)
        );

        if (results.Count == 0)
        {
            Console.WriteLine("No se encontraron coincidencias.");
            return;
        }

        Console.WriteLine("Coincidencias encontradas:");
        foreach (string r in results)
        {
            Console.WriteLine($"- {r}");
        }
    }
}

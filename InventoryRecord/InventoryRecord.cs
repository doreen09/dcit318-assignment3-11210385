using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public interface IInventoryEntity
{
    int Id { get; }
}

public record InventoryItem(
    int Id,
    string Name,
    int Quantity,
    DateTime DateAdded) : IInventoryEntity;


public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return new List<T>(_log);
    }

    public void SaveToFile()
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                _log = JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
                Console.WriteLine("Data loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved data found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }
}

public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
        _logger.Add(new InventoryItem(2, "Mouse", 10, DateTime.Now));
        _logger.Add(new InventoryItem(3, "Keyboard", 7, DateTime.Now));
        _logger.Add(new InventoryItem(4, "Monitor", 3, DateTime.Now));
        _logger.Add(new InventoryItem(5, "Printer", 2, DateTime.Now));
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        var items = _logger.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
        }
    }
}

class InventoryRecord 
{
    static void Main()
    {
        string filePath = "inventory.json";

        InventoryApp app = new InventoryApp(filePath);
        app.SeedSampleData();
        app.SaveData();

        Console.WriteLine("\n--- Simulating new session ---\n");
        InventoryApp newApp = new InventoryApp(filePath);
        newApp.LoadData();
        newApp.PrintAllItems();
    }
}


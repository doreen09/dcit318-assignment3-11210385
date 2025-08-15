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


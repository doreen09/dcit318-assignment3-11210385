# dcit318-assignment3-11210385
 
This repository contains five C# console applications implementing different systems as part of DCIT 318 coursework.  

## Projects Overview

### 1. **Finance Management System**  
Tracks financial transactions, enforces data integrity, and supports multiple payment methods.  
- **Key Features:**
  - Transaction tracking with amount, date, and type.
  - Implementation of `ITransactionProcessor` interface.
  - Concrete classes: `BankTransferProcessor`, `MobileMoneyProcessor`, `CryptoWalletProcessor`.
  
- **How to Run:**
  ```bash
  cd FinanceMgt
  dotnet run


### 2. Healthcare System

Manages patient records and prescriptions using Collections and Generics for scalability and type safety.

**Key Features:**

- Generic repository Repository<T> for entity management.

- Classes: Patient and Prescription.

- Uses Dictionary<int, List<Prescription>> to group prescriptions by patient.

- Retrieves prescriptions by patient ID.

- **How to Run:**
  ```bash
  cd Healthcare
  dotnet run


### 3. Warehouse Inventory Management System
Uses collections, generics, and custom exception handling to manage product inventory..

**Key Features:**

- Marker interface IInventoryItem.

- Product classes: ElectronicItem and GroceryItem.

- Generic repository InventoryRepository<T> with custom exceptions:

DuplicateItemException

ItemNotFoundException

InvalidQuantityException

- Exception-safe inventory operations.


- **How to Run:**
  ```bash
  cd WareHouse
  dotnet run


### 4. **School Grading System**  
Reads student data from a .txt file, validates and processes it, and writes a report to a new file with assigned grades.

- **Key Features:**
-Student class with grading logic.

- Custom exceptions:

  InvalidScoreFormatException
  MissingFieldException

- File I/O using StreamReader and StreamWriter.

- Generates a formatted report.
  
- **How to Run:**
  ```bash
  cd GradingSystem
  dotnet run

**Note:** Ensure students.txt exists in the same folder.


### 4. **Inventory System**  
Captures inventory records using C# records, generics, and file operations for persistent storage.

- **Key Features:**
- Immutable InventoryItem record implementing IInventoryEntity.

- Generic InventoryLogger<T> for logging and saving data.

- JSON or plain-text file storage.

- Loads data back into memory for verification.

- **How to Run:**
  ```bash
  cd GradingSystem
  dotnet run
  
## Requirements

.NET SDK 6.0+

**Notes**

- Each project is independent and must be run from its own folder.

- Use dotnet build before dotnet run if you want to verify compilation.
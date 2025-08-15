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


### 2. Grading System

Calculates student grades from a text file and assigns letter grades.

**Key Features:**

- Reads students.txt file.

- Calculates total score and determines letter grade.

- Handles missing/invalid data.

- **How to Run:**
  ```bash
  cd GradingSystem
  dotnet run


**Note:** Ensure students.txt exists in the same folder.

### 3. Inventory Record System

Maintains records of items in stock.

**Key Features:**

- Uses a C# record type for immutability.

- Stores Id, Name, Quantity, and DateAdded.

- Displays inventory in tabular form.

**How to Run:**
- ```bash
cd InventoryRecord
dotnet run

### 4. Student Registration System

Registers students and displays stored data.

**Key Features:**

- Stores student information (Name, ID, Program).

- Allows new entries via console input.

- Displays all registered students.

**How to Run:**
- ```bash
cd StudentRegistration
dotnet run

### 5. Library Management System

Manages books, borrowers, and loans.

**Key Features:**

- Adds books and borrowers.

- Issues and returns books.

- Displays all records.

**How to Run:**
- ```bash
cd LibraryManagement
dotnet run

## Requirements

.NET SDK 6.0+

**Notes**

- Each project is independent and must be run from its own folder.

- Use dotnet build before dotnet run if you want to verify compilation.
# EF10_LeftJoin_RightJoin_Sample

For more information about this post visit this site:

https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew#linq-and-sql-translation

## 1. Donwload and run SQL Server docker image

First of all we have to run **Docker Desktop**

![image](https://github.com/user-attachments/assets/716d31d4-88d4-417c-a38f-80db93a74f05)

For a detail explanation visit the github repo:

https://github.com/luiscoco/SQL-Server-Docker-container/blob/main/README.md

We run this command to download **SQL Server** docker image and run it with docker:

```
docker run ^
  -e "ACCEPT_EULA=Y" ^
  -e "MSSQL_SA_PASSWORD=Luiscoco123456" ^
  -p 1433:1433 ^
  -d mcr.microsoft.com/mssql/server:2022-latest
```

## 2. Connect to SQL Server with SSMS 

Download **SSMS (SQL Server Management Studio)** and install it:

https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms

We connect to the SSMS with the password: Luiscoco123456

![image](https://github.com/user-attachments/assets/2a30aedc-54b4-42f4-bac5-29a44bc70dfe)

![image](https://github.com/user-attachments/assets/2ddf95dc-aac1-4e0b-8e09-0375deb53a3b)

## 3. Create the Database and Tables in SSMS

```sql
-- Create the database
CREATE DATABASE SchoolDB;
GO

-- Use the created database
USE SchoolDB;
GO

-- Create Departments table
CREATE TABLE Departments (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);
GO

-- Create Students table
CREATE TABLE Students (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DepartmentID INT NULL FOREIGN KEY REFERENCES Departments(ID)
);
GO

-- Insert sample data into Departments
INSERT INTO Departments (Name) VALUES
('Engineering'),
('Human Resources'),
('Marketing');
GO

-- Insert sample data into Students
INSERT INTO Students (FirstName, LastName, DepartmentID) VALUES
('John', 'Doe', 1),        -- Engineering
('Jane', 'Smith', 2),      -- Human Resources
('Michael', 'Brown', NULL),-- No Department
('Emily', 'Davis', 3),     -- Marketing
('Chris', 'Wilson', 1),    -- Engineering
('Anna', 'Taylor', NULL);  -- No Department
GO
```

We check the above queries

```sql
SELECT TOP (1000) [ID]
      ,[Name]
  FROM [SchoolDB].[dbo].[Departments]
```

![image](https://github.com/user-attachments/assets/0c9ae900-630c-4dc0-ab1d-97fa11262cd8)

```sql
SELECT TOP (1000) [ID]
      ,[FirstName]
      ,[LastName]
      ,[DepartmentID]
  FROM [SchoolDB].[dbo].[Students]
```

![image](https://github.com/user-attachments/assets/19e36224-97a7-45dc-8e29-e2935499244c)


## 3. Download and Install Visual Studio 2022 v17.4 (Preview version)

Download and Install Visual Studio 2022 Preview version from this site: 

https://visualstudio.microsoft.com/vs/preview/

![image](https://github.com/user-attachments/assets/be8914ff-f78d-4325-9b5b-bf85f0f585d0)

When running the Visual Strudio installer please select and install ASP.NET Core, Azure and Desktop 

![image](https://github.com/user-attachments/assets/a40c34a7-2a1e-49bc-9e84-511da29d1e5a)

## 4. Download and Install .NET 10 

![image](https://github.com/user-attachments/assets/3e1eed60-2476-4c79-a545-57c472491fd9)

Check the installation running this command

```
dotnet --version
```

![image](https://github.com/user-attachments/assets/274068f4-8135-42cf-b0da-76e8fc244643)

## 5. We create a new C# console application with .NET 10 and Visual Studio 2022 v17.4 (Preview)

Run Visual Studio 2022

![image](https://github.com/user-attachments/assets/73f9c2c7-4700-4c2e-89eb-1a1a49a7f33f)

We create a new project

![image](https://github.com/user-attachments/assets/2e36b18c-d1d8-4dc3-867c-89d57014764c)

We select the project template and press the Next button

![image](https://github.com/user-attachments/assets/3e3af5fe-9b3d-4f31-a541-4c6ec5164d93)

We set the project name and location and press the Next button

![image](https://github.com/user-attachments/assets/1d6676a0-31a4-492f-aa32-f6f52f3840e2)

We select the .NET 10 frameworkd and press the Create button

![image](https://github.com/user-attachments/assets/3a9a1510-6986-4421-9daa-017be34a414d)

## 6. We load the Nuge packages

![image](https://github.com/user-attachments/assets/39198c89-b8ea-49b9-91df-18264cbaa632)

## 7. We create the project folder and files structure

![image](https://github.com/user-attachments/assets/079c428a-e289-4a89-96ee-2a3dc20ecaf4)

## 8. We input the Data Models code

```csharp
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; } = null!;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
```


```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentID { get; set; }

        public Department? Department { get; set; }
    }
}
```

## 9. We input the DbContext code

```csharp
using EF10_LeftJoin_RightJoin_Sample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SchoolDB;User Id=sa;Password=Luiscoco123456;TrustServerCertificate=True;");
        }
    }
}
```

## 10. We input the Program.cs code

```csharp
using EF10_LeftJoin_RightJoin_Sample.Data;

using var context = new SchoolContext();

var leftJoinQuery = context.Students
    .LeftJoin(
        context.Departments,
        student => student.DepartmentID,
        department => department.ID,
        (student, department) => new
        {
            student.FirstName,
            student.LastName,
            Department = department.Name ?? "[NONE]"
        });

foreach (var item in leftJoinQuery)
{
    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Department}");
}
```

## 11. We run the application and verify the results

We fun the C# console application and see the results

![image](https://github.com/user-attachments/assets/5b2fa3a7-fbfd-497e-a400-0e011a9ae4d6)

We compare the result running the query in SSMS:

```sql
SELECT s.FirstName, s.LastName, ISNULL(d.Name, '[NONE]') AS Department
FROM Students s
LEFT JOIN Departments d ON s.DepartmentID = d.ID
```

![image](https://github.com/user-attachments/assets/ce9dccc1-8b8f-48f1-b72f-1d1f8c4e867f)

## 12. We can also customize the application for the RightJoin command

```csharp
using EF10_LeftJoin_RightJoin_Sample.Data;

using var context = new SchoolContext();

var rightJoinQuery = context.Students
    .RightJoin(
        context.Departments,
        student => student.DepartmentID,
        department => department.ID,
        (student, department) => new
        {
            StudentName = student != null ? $"{student.FirstName} {student.LastName}" : "[NONE]",
            department.Name
        });

foreach (var item in rightJoinQuery)
{
    Console.WriteLine($"{item.StudentName} - {item.Name}");
}
```

## 13. We run the application and verify the results

We fun the C# console application and see the results

![image](https://github.com/user-attachments/assets/421164e0-c0fa-4b42-9236-b2e778df268b)

We compare the result running the query in SSMS:

```sql
SELECT ISNULL(s.FirstName + ' ' + s.LastName, '[NONE]') AS StudentName, d.Name
FROM Students s
RIGHT JOIN Departments d ON s.DepartmentID = d.ID
```

![image](https://github.com/user-attachments/assets/fd69ed35-e07e-4930-835d-921be70f58f0)


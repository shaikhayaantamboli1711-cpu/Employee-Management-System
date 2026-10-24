# Employee Management System

A Windows Forms desktop application for managing employee records, built with **C#**, **.NET** and **SQL Server (LocalDB)**. It supports full CRUD operations (Create, Read, Update, Delete) with a clean, modern interface.

<img width="987" height="867" alt="image" src="https://github.com/user-attachments/assets/d0d672d0-2ee2-4bd2-953f-daa501e18bec" />



---

## Features

- **Add, update and delete** employee records
- **Auto-created database:** the database and table are generated on first run, with no manual setup needed
- **Modern UI:** card layout, color-coded buttons and a styled data grid with alternating rows
- **Input validation:** required fields and email format checks
- **Duplicate protection:** unique Employee ID and unique Email, with friendly error messages
- **Click-to-edit:** select a row in the grid to load it into the form
- **Safe database access:** parameterized queries to prevent SQL injection
- **Delete confirmation** before removing a record
- **Live record count** in the status bar

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| UI | Windows Forms (.NET) |
| Database | SQL Server |
| Data access | ADO.NET with `Microsoft.Data.SqlClient` |
| IDE | Visual Studio 2026 |

---

## Project Structure

```
StudentCrud/
├── StudentCrud.cs                 # Main form: UI logic, validation, event handlers
├── StudentCrud.Designer.cs        # Designer-generated layout code
├── EmployeeRepository.cs          # Data access layer (all SQL lives here)
├── EmployeeDB.sql                 # Optional manual database script
├── Program.cs                     # Application entry point
└── README.md
```

---

## Prerequisites

- Windows 10 or 11
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload
- **SQL Server Express LocalDB** (included with Visual Studio; in the Visual Studio Installer, tick it under *Data storage and processing*)

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/<your-username>/<your-repo-name>.git
cd <your-repo-name>
```

### 2. Open the solution

Open the `.sln` file in Visual Studio.

### 3. Restore NuGet packages

Visual Studio restores packages automatically on build. If it doesn't, run:

```bash
dotnet restore
```

The project uses:

```
Microsoft.Data.SqlClient
```

### 4. Run the application

Press **F5**. On first launch the app automatically:

1. Creates the `EmployeeDB` database
2. Creates the `Employees` table
3. Loads the (empty) grid

No manual database setup is required.

---

## Database

### Schema

**Table: `dbo.Employees`**

| Column | Type | Constraints |
|---|---|---|
| `EmployeeId` | NVARCHAR(20) | Primary key |
| `EmployeeName` | NVARCHAR(100) | Required |
| `Email` | NVARCHAR(150) | Required, unique |
| `Department` | NVARCHAR(50) | Required |
| `CreatedAt` | DATETIME2 | Default: current date and time |

### Manual setup (optional)

If you prefer to create the database yourself, run `EmployeeDB.sql` in SQL Server Object Explorer, SSMS or Azure Data Studio. The script also inserts three sample employees.

### Changing the connection string

Connection strings are defined at the top of `EmployeeRepository.cs`. The default targets LocalDB:

```
Server=(localdb)\MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;
```

For SQL Server Express or a full SQL Server instance, change the `Server=` value in both `MasterConn` and `DbConn`:

| Instance | Server value |
|---|---|
| SQL Express | `.\SQLEXPRESS` |
| Named server | `YOUR-PC-NAME` |

> **Security note:** for production use, move the connection string to configuration (for example `appsettings.json`) and avoid committing credentials to source control.

---

## Usage

| Action | How |
|---|---|
| **Add** | Fill in all fields and click **Submit** |
| **Edit** | Click a row in the grid, change the fields and click **Update** (Employee ID is locked) |
| **Delete** | Click a row and click **Delete**, then confirm |
| **Reset form** | Click **Clear** |

---

## UI Design Reference

| Element | Value |
|---|---|
| Form background | `#F3F5F9` |
| Header | `#1F3A5F` with `#2563EB` accent line |
| Primary button (Submit) | `#2563EB` |
| Success button (Update) | `#16A34A` |
| Danger button (Delete) | `#DC2626` |
| Grid header | `#1F3A5F`, white text |
| Selected row | `#DBEAFE` |
| Font | Segoe UI |

---

## Troubleshooting

| Problem | Solution |
|---|---|
| *Network-related or instance-specific error* | LocalDB isn't installed. Add **SQL Server Express LocalDB** via the Visual Studio Installer. |
| *Method already defined* | A button was double-clicked in the designer, creating a duplicate handler. Delete the empty duplicate. |
| *Column 'ID' does not belong to table* | The grid has manually added columns. Remove them so it binds automatically. |
| *Name does not exist in the current context* | A control name in the designer doesn't match the code (`txtId`, `txtName`, `txtEmail`, `cmbDepartment`, `dgvEmployees`, `lblStatus`, `btnSubmit`, `btnUpdate`, `btnDelete`, `btnClear`). |

---

## Roadmap

- [ ] Search and filter employees
- [ ] Export records to Excel or CSV
- [ ] Additional fields (phone, join date, salary)
- [ ] Move connection string to `appsettings.json`
- [ ] Pagination for large datasets
- [ ] Unit tests for the repository layer

---

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a Pull Request
---

## Author
[Ayaan](https://github.com/shaikhayaantamboli1711-cpu)

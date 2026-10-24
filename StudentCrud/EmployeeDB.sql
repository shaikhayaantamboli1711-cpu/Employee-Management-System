
-- =====================================================
-- Employee Management Database (SQL Server / LocalDB)
-- =====================================================
IF DB_ID('EmployeeDB') IS NULL
    CREATE DATABASE EmployeeDB;
GO
 
USE EmployeeDB;
GO
 
IF OBJECT_ID('dbo.Employees', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Employees
    (
        EmployeeId   NVARCHAR(20)  NOT NULL PRIMARY KEY,
        EmployeeName NVARCHAR(100) NOT NULL,
        Email        NVARCHAR(150) NOT NULL,
        Department   NVARCHAR(50)  NOT NULL,
        CreatedAt    DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
        CONSTRAINT UQ_Employees_Email UNIQUE (Email)
    );
END
GO
 
-- Optional sample data
IF NOT EXISTS (SELECT 1 FROM dbo.Employees)
BEGIN
    INSERT INTO dbo.Employees (EmployeeId, EmployeeName, Email, Department) VALUES
    ('101', 'Anita Sharma',  'anita.sharma@company.com',  'Human Resources'),
    ('102', 'Rahul Verma',   'rahul.verma@company.com',   'Finance'),
    ('103', 'Priya Reddy',   'priya.reddy@company.com',   'Engineering');
END
GO
 
SELECT * FROM dbo.Employees;
GO


using Microsoft.Data.SqlClient;
using System.Data;

 
namespace StudentCrud
{
    public class EmployeeRepository
    {
        // LocalDB ships with Visual Studio. For full SQL Server use e.g.
        // "Server=.\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
        private const string MasterConn =
            "Server=DESKTOP-FG58ET6;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        private const string DbConn =
            "Server=DESKTOP-FG58ET6;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Creates the database and table automatically if they don't exist.
        public void EnsureDatabase()
        {
            using (var con = new SqlConnection(MasterConn))
            {
                con.Open();
                using var cmd = new SqlCommand(
                    "IF DB_ID('EmployeeDB') IS NULL CREATE DATABASE EmployeeDB;", con);
                cmd.ExecuteNonQuery();
            }

            using (var con = new SqlConnection(DbConn))
            {
                con.Open();
                const string sql = @"
                    IF OBJECT_ID('dbo.Employees','U') IS NULL
                    CREATE TABLE dbo.Employees
                    (
                        EmployeeId   NVARCHAR(20)  NOT NULL PRIMARY KEY,
                        EmployeeName NVARCHAR(100) NOT NULL,
                        Email        NVARCHAR(150) NOT NULL,
                        Department   NVARCHAR(50)  NOT NULL,
                        CreatedAt    DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
                        CONSTRAINT UQ_Employees_Email UNIQUE (Email)
                    );";
                using var cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using var con = new SqlConnection(DbConn);
            using var da = new SqlDataAdapter(
                @"SELECT EmployeeId AS ID, EmployeeName AS Name, Email, Department
                  FROM dbo.Employees ORDER BY EmployeeId", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Exists(string id)
        {
            using var con = new SqlConnection(DbConn);
            using var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM dbo.Employees WHERE EmployeeId = @id", con);
            cmd.Parameters.AddWithValue("@id", id); 
            con.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public void Insert(string id, string name, string email, string dept)
        {
            using var con = new SqlConnection(DbConn);
            using var cmd = new SqlCommand(
                @"INSERT INTO dbo.Employees (EmployeeId, EmployeeName, Email, Department)
                  VALUES (@id, @name, @email, @dept)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@dept", dept);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public int Update(string id, string name, string email, string dept)
        {
            using var con = new SqlConnection(DbConn);
            using var cmd = new SqlCommand(
                @"UPDATE dbo.Employees
                  SET EmployeeName = @name, Email = @email, Department = @dept
                  WHERE EmployeeId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@dept", dept);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(string id)
        {
            using var con = new SqlConnection(DbConn);
            using var cmd = new SqlCommand(
                "DELETE FROM dbo.Employees WHERE EmployeeId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}



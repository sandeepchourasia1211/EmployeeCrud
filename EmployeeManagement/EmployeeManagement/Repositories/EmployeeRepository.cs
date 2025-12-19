using Dapper;
using EmployeeManagement.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

        public List<Employee> GetAll()
        {
            using var con = new SqlConnection(_connectionString);

            return con.Query<Employee>(
                "sp_GetAllEmployees",
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public Employee GetById(int id)
        {
            using var con = new SqlConnection(_connectionString);

            return con.QueryFirstOrDefault<Employee>
                (
                "sp_GetEmployeeById", new { EmployeeId = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Add(Employee emp)
        {
            using var con = new SqlConnection(_connectionString);

            con.Execute(
                "sp_AddEmployee",
                new
                {
                    emp.EName,
                    emp.Age,
                    emp.Salary
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Update(int id, Employee emp)
        {
            using var con = new SqlConnection(_connectionString);

            con.Execute(
                "sp_UpdateEmployee",
                new
                {
                    EmployeeId = id,
                    emp.EName,
                    emp.Age,
                    emp.Salary
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(int id)
        {
            using var con = new SqlConnection(_connectionString);

            con.Execute(
                "sp_DeleteEmployee",
                new { EmployeeId = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

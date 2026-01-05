using Dapper;
using EmployeeManagement.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(
                "usp_Employee_GetAll",
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "usp_Employee_Insert",
                new
                {
                    employee.Name,
                    employee.Email,
                    employee.Department
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}

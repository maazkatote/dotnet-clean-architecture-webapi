using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Email = e.Email,
                Department = e.Department,
                IsActive = e.IsActive,
                CreatedDate = e.CreatedDate,
                ModifiedDate = e.ModifiedDate
            });
        }

        public async Task AddAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Department = employeeDto.Department
            };

            await _repository.AddAsync(employee);
        }

    }
}

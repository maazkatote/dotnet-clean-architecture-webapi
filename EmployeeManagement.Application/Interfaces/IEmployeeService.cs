using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task AddAsync(EmployeeDto employee);
    }
}

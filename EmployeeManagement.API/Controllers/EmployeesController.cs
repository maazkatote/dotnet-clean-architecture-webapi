using Asp.Versioning;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("/GetAllEmployee")]
        public async Task<IActionResult> Get()
        {
            //get employee
            return Ok(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("/AddEmployee")]
        public async Task<IActionResult> Post(EmployeeDto employee)
        {
            await _service.AddAsync(employee);
            return Ok("employee added successfully");
        }
    }
}

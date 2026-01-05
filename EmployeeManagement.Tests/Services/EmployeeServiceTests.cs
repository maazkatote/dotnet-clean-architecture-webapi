using EmployeeManagement.Application.Services;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeManagement.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Name = "John", Email = "john@test.com", Department = "IT" },
                new Employee { Name = "Jane", Email = "jane@test.com", Department = "HR" }
            };

            _repositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(employees);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(2);
            result.First().Name.Should().Be("John");
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository()
        {
            // Arrange
            var dto = new EmployeeDto
            {
                Name = "Alice",
                Email = "alice@test.com",
                Department = "Finance"
            };

            // Act
            await _service.AddAsync(dto);

            // Assert
            _repositoryMock.Verify(
                repo => repo.AddAsync(It.Is<Employee>(
                    e => e.Name == dto.Name &&
                         e.Email == dto.Email &&
                         e.Department == dto.Department
                )),
                Times.Once
            );
        }



    }
}

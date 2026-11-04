
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET all employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return Ok(employees);
        }

        // GET employee by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        // POST add employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var newEmployee = await _employeeService.AddEmployeeAsync(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = newEmployee.Id },
                newEmployee
            );
        }

        // PUT update employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, updatedEmployee);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        // DELETE employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool isDeleted = await _employeeService.DeleteEmployeeAsync(id);

            if (!isDeleted)
            {
                return NotFound("Employee not found");
            }

            return NoContent();
        }
    }
}


using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Sanjay", Department = "IT", Salary = 30000 },
            new Employee { Id = 2, Name = "Rahul", Department = "HR", Salary = 25000 }
        };

        // GET all employees
        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(employees);
        }

        // GET employee by ID
        public Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            return Task.FromResult(employee);
        }

        // POST add employee
        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.Id = employees.Count == 0
                ? 1
                : employees.Max(e => e.Id) + 1;

            employees.Add(employee);

            return Task.FromResult(employee);
        }

        // PUT update employee
        public Task<Employee?> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return Task.FromResult<Employee?>(null);
            }

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;

            return Task.FromResult<Employee?>(employee);
        }

        // DELETE employee
        public Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return Task.FromResult(false);
            }

            employees.Remove(employee);

            return Task.FromResult(true);
        }
    }
}

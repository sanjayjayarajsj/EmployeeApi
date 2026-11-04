using System.ComponentModel.DataAnnotations;
namespace EmployeeApi.Models

{

    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Position is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Position cannot exceed 50 characters")]
        public string Department { get; set; } = string.Empty;


        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }
    }
    }


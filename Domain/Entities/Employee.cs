using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    [Required,MaxLength (100)] 
    public string FirstName { get; set; }
    [Required,MaxLength (100)] 
    public string LastName { get; set; }
    [Required] 
    public Gender Gender { get; set; }
    [Required] 
    public DateTime HireDate { get; set; }
    public List<Salary> Salaries { get; set; }
    public List<DepartmentManager> DepartmentManagers { get; set; }
    public List<DepartmentEmployee> departmentEmployees { get; set; }
}


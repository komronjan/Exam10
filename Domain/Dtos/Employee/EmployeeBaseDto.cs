using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Employee;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string FirstName { get; set; }
    [Required, MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public int Gender { get; set; }
    [Required]
    public DateTime HireDate { get; set; }

}

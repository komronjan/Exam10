using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DepartmentManager
{
    public int EmployeeId { get; set; }
    [Required] 
    public Employee Employee { get; set; }
    [Required] 
    public int DepartmentId { get; set; }
    [Required] 
    public Department Department { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime TODate { get; set; }

}

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DepartmentEmployee
{
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }   
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    [Required] 
    public DateTime FromDate  { get; set; }
    [Required] 
    public DateTime ToDate { get; set; }
}

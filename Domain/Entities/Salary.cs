using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Salary
{
    public long Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    [Required] 
    public long Amount { get; set; }
    [Required] 
    public DateTime FromDate { get; set; }
    [Required] 
    public DateTime ToDate { get; set; }
}

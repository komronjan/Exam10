using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Salary;

public class SalaryBaseDto
{
    public long Id { get; set; }
    public int EmployeeId { get; set; }
    [Required]
    public long Amount { get; set; }
    [Required]
    public DateTime FromDate { get; set; }
    [Required]
    public DateTime ToDate { get; set; }
}

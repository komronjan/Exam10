using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.DepartmentEmployee;

public class DepartmentEmployeeBaseDto
{
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
    [Required]
    public DateTime FromDate { get; set; }
    [Required]
    public DateTime ToDate { get; set; }
}

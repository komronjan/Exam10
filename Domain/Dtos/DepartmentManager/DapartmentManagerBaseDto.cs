using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.DepartmentManager;

public class DapartmentManagerBaseDto
{
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
    [Required]
    public DateTime FromDate { get; set; }
    [Required]
    public DateTime ToDate { get; set; }
}

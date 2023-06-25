namespace Domain.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DepartmentEmployee> DepartmentEmployees { get; set; }
    public List<DepartmentManager> departmentManagers { get; set; }
    
}

using Domain.Dtos.DepartmentManager;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class ManagerService
{
    private readonly DataContext context;

    public ManagerService(DataContext context)
    {
        this.context = context;
    }
    public async Task<List<GetDapartmentManagerDto>> Get()
    {

        return context.departmentManagers.Select(x => new GetDapartmentManagerDto()
        {
            EmployeeId = x.EmployeeId,
            DepartmentId = x.DepartmentId,
            FirstName = x.Employee.FirstName,
            LastName = x.Employee.LastName,
            FromDate = x.FromDate,
            ToDate = x.TODate
        }).ToList();

    }

    public async Task<GetDapartmentManagerDto> Add(AddDapartmentManagerDto model)
    {
        model.FromDate = DateTime.SpecifyKind(model.FromDate, DateTimeKind.Utc);
        model.ToDate = DateTime.SpecifyKind(model.ToDate, DateTimeKind.Utc);
        var departmentManager = new DepartmentManager()
        {
            EmployeeId = model.EmployeeId,
            DepartmentId = model.DepartmentId,
            FromDate = model.FromDate,
            TODate = model.ToDate
        };
        await context.departmentManagers.AddAsync(departmentManager);
        await context.SaveChangesAsync();
        return new GetDapartmentManagerDto()
        {
            EmployeeId = departmentManager.EmployeeId,
            DepartmentId = departmentManager.DepartmentId,
            FromDate = departmentManager.FromDate,
            ToDate = departmentManager.TODate,
            FirstName = departmentManager.Employee.FirstName,
            LastName = departmentManager.Employee.LastName
        };
    }

}

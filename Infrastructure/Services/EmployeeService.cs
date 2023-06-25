using Domain.Dtos.Employee;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext context;

    public EmployeeService(DataContext context)
    {
        this.context = context;
    }
    public async Task<List<GetEmployeeDto>> Get()
    {
        return context.Employees.Select(x => new GetEmployeeDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            HireDate = x.HireDate,
            Gender = (int)x.Gender,
        }).ToList();
    }
    public async Task<GetEmployeeDto> GetById(int id)
    {
        var find = await context.Employees.FindAsync(id);
        return new GetEmployeeDto()
        {

            Id = find.Id,
            FirstName = find.FirstName,
            LastName = find.LastName,
            HireDate = find.HireDate,
            Gender = (int)find.Gender,

        };
    }
    public async Task<GetEmployeeDto> Add(AddEmployeeDto model)
    {        
        model.HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc);
        var employee = new Employee()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            HireDate = model.HireDate,
            Gender = (Gender)model.Gender,
        };
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
        return new GetEmployeeDto()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            HireDate = model.HireDate,
            Gender = (int)model.Gender,
        };
    }
    public async Task<GetEmployeeDto> Update(AddEmployeeDto model)
    {
        model.HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc);
        var find = await context.Employees.FindAsync(model.Id);
        find.Id = model.Id;
        find.FirstName = model.FirstName;
        find.LastName = model.LastName;
        find.HireDate = model.HireDate;
        find.Gender = (Gender)model.Gender;
        await context.SaveChangesAsync();
        return new GetEmployeeDto()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            HireDate = model.HireDate,
            Gender = (int)model.Gender,
        };
    }
}

using Domain.Dtos.Department;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext context;

    public DepartmentService(DataContext context)
    {
        this.context = context;
    }
    public async Task<List<GetDepartmentDto>> Get()
    {
        return context.Departments.Select(x => new GetDepartmentDto()
        {
            Name = x.Name,
            Id = x.Id
        }).ToList();
    }
    public async Task<GetDepartmentDto> GetById(int id)
    {
        var find = await context.Departments.FindAsync(id);
        return new GetDepartmentDto()
        {
            Name = find.Name,
            Id = find.Id
        };
    }
    public async Task<GetDepartmentDto> Add(AddDepartmentDto model)
    {
        var department = new Department()
        {
            Name = model.Name,
            Id = model.Id
        };
        await context.Departments.AddAsync(department);
        await context.SaveChangesAsync();
        return new GetDepartmentDto()
        {
            Name = model.Name,
            Id = model.Id
        };
    }
    public async Task<GetDepartmentDto> Update(AddDepartmentDto model)
    {
        var find = await context.Departments.FindAsync(model.Id);
        find.Name = model.Name;
        await context.SaveChangesAsync();
        return new GetDepartmentDto()
        {
            Name = model.Name,
            Id = model.Id
        };
    }
}

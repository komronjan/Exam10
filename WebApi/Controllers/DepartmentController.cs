using Domain.Dtos.Department;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        this.departmentService = departmentService;
    }
    [HttpGet("Get")]
    public async Task<List<GetDepartmentDto>> Get()
    {
        return await departmentService.Get();
    }
    [HttpGet("GetById")]
    public async Task<GetDepartmentDto> GetById(int id)
    {
        return await departmentService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<GetDepartmentDto> Add(AddDepartmentDto departmentDto)
    {
        return await departmentService.Add(departmentDto);
    }
    [HttpPut("Update")]
    public async Task<GetDepartmentDto> Update(AddDepartmentDto departmentDto)
    {
        return await departmentService.Update(departmentDto);
    }

}

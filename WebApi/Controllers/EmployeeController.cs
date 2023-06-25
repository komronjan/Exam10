using Domain.Dtos.Employee;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }
    [HttpGet("Get")]
    public async Task<List<GetEmployeeDto>> Get()
    {
        return await employeeService.Get();
    }
    [HttpGet("GetById")]
    public async Task<GetEmployeeDto> GetById(int id)
    {
        return await employeeService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<GetEmployeeDto> Add(AddEmployeeDto employeeDto)
    {
        return await employeeService.Add(employeeDto);
    }
    [HttpPut("Update")]
    public async Task<GetEmployeeDto> Update(AddEmployeeDto employeeDto)
    {
        return await employeeService.Update(employeeDto);
    }

}

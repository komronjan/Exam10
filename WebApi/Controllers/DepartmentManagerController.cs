using Domain.Dtos.DepartmentManager;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentManagerController : ControllerBase
{
    private readonly ManagerService managerService;

    public DepartmentManagerController(ManagerService managerService)
    {
        this.managerService = managerService;
    }
    [HttpGet("Get")]
    public async Task<List<GetDapartmentManagerDto>> Get()
    {
        return await managerService.Get();
    }
    [HttpPost("Add")]
    public async Task<GetDapartmentManagerDto> Add(AddDapartmentManagerDto dapartmentManagerDto)
    {
        return await managerService.Add(dapartmentManagerDto);
    }
}

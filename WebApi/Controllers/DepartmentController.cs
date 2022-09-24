using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Domain.Entities;

[ApiController]
[Route("[controller]")]
public class DepartmentControler : ControllerBase
{
    private DepartmentService DepartmentService;
    public DepartmentControler (DepartmentService DepartmentService)
    {
        DepartmentService = DepartmentService;
    }
  

    [HttpGet("getDepartments")]
    public async Task<Response<List<Department>>> GetDepartment()
    {
        return await DepartmentService.GetDepartments();
    }

    [HttpPost("addDepartment")]
    public async Task<Response<Department>> AddDepartment(Department Department)
    {
        return await DepartmentService.AddDepartment(Department);
    }

    [HttpPut("updateDepartment")]
    public async Task<Response<Department>> UpdateDepartment(Department Department)
    {
       return await DepartmentService.UpdateDepartment(Department);
    }

    [HttpDelete("deleteDepartments")]
    public async Task<Response<int>> DeleteDepartment(int id)
    {
        return await DepartmentService.DeleteDepartment(id);
    }

}
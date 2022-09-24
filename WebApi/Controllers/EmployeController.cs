using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;

[ApiController]
[Route("[controller]")]
public class EmployeeControler : ControllerBase
{
    private EmployeeService EmployeeService;
    public EmployeeControler(EmployeeService employeeService)
    {
        EmployeeService = employeeService;
    }
  

    [HttpGet("getEmployees")]
    public async Task<Response<List<Employee>>> GetEmploye()
    {
        return await EmployeeService.GetEmployees();
    }

    [HttpPost("addEmployee")]
    public async Task<Response<Employee>> AddEmploye(Employee Employee)
    {
        return await EmployeeService.AddEmployee(Employee);
    }

    [HttpPut("updateEmployee")]
    public async Task<Response<Employee>> UpdateEmploye(Employee Employee)
    {
       return await EmployeeService.UpdateEmployee(Employee);
    }

    [HttpDelete("deleteEmployees")]
    public async Task<Response<int>> DeleteEmploye(int id)
    {
        return await EmployeeService.DeleteEmployee(id);
    }

}
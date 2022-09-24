namespace Infrastructure.Service;
using Dapper;
using Domain.Wrapper;
using Infrastructure.DataContext;

public class EmployeeService
{
    private DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Employee>>> GetEmployees()
    {
        await using var connection = _context.CreateConnection();
        var sql = "select  * from Employee";
        var result = await connection.QueryAsync<Employee>(sql);
        return new Response<List<Employee>>(result.ToList());
    }

    public async Task<Response<Employee>> AddEmployee(Employee Employee)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql =
                "insert into Employee (FirstName, LastName, BirhDate,Gender) values (@FirstName, @LastName, @BirhDate,@Gender) returning id;";
            var result =
                await connection.ExecuteScalarAsync<int>(sql,
                    new { Employee.FirstName, Employee.LastName, Employee.BirhDate,Employee.Gender });
            Employee.Id = result;
            return new Response<Employee>(Employee);
        }
        catch (Exception ex)
        {
            return new Response<Employee>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<Employee>> UpdateEmployee(Employee Employee)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
           var sql ="insert into Employee (FirstName, LastName, BirhDate,Gender) values (@FirstName, @LastName, @BirhDate,@Gender) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql,  new { Employee.FirstName, Employee.LastName, Employee.BirhDate,Employee.Gender });
            Employee.Id = result;
            return new Response<Employee>(Employee);
        }
        }
         catch (Exception ex)
        {     
           return new Response<Employee>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }  
       
    }

    public async Task<Response<int>> DeleteEmployee(int id)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"delete from Employee where Id = {id}";
            var response  = await connection.ExecuteScalarAsync<int>(sql);
            id = response;
            return new Response<int>(response);
        }
        }
         catch (Exception ex)
        {
           return new Response<int>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    } 
}
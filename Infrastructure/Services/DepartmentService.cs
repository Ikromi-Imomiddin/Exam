using Npgsql;
using Dapper;
using Domain.Wrapper;
using Domain.Entities;
using Infrastructure.DataContext;

public class DepartmentService
{
   private DataContext _context;
     public DepartmentService (DataContext context)
    {
        _context = context;
    }

     public async Task<Response<List<Department>>> GetDepartments()
    {
        await using var connection = _context.CreateConnection();
        var sql = "select  * from Department";
        var result = await connection.QueryAsync<Department>(sql);
        return new Response<List<Department>>(result.ToList());
    }

     public async Task<Response<Department>> AddDepartment(Department Department)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = "insert into Department (Name, DepartmentId) values (@Name, @DepartmentId) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql, new { Department.Name, Department.DepartmentId});
            Department.DepartmentId = result;
            return new Response<Department>(Department);
        }
        catch (Exception ex)
        {
            return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

      public async Task<Response<Department>> UpdateDepartment(Department Department)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
           var sql ="insert into Department (Name, DepartmentId) values (@Name, @DepartmentId) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql,  new { Department.Name, Department.DepartmentId});
            Department.DepartmentId = result;
            return new Response<Department>(Department);
        }
        }
         catch (Exception e)
        {     
           return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }  
       
    }

    public async Task<Response<int>> DeleteDepartment(int id)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"delete from Department where DepartmentId = {id}";
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

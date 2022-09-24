// using Domain.Entities;
// using Domain.Wrapper;

// namespace Infrastructure.Services;

// using Dapper;
// using Infrastructure.DataContext;

// public class ManagerService
// {
//    private DataContext _context;
//      public ManagerService (DataContext context)
//     {
//         _context = context;
//     }

//      public async Task<Response<List<ManagerService>>> GetManagers()
//     {
//         await using var connection = _context.CreateConnection();
//         var sql = "select  () from Manager";
//         var result = await connection.QueryAsync<Manager>(sql);
//         return new Response<List<Manager>>(result.ToList());
//     }

//      public async Task<Response<Manager>> AddManager(Manager Manager)
//     {
//         using var connection = _context.CreateConnection();
//         try
//         {
//             var sql = "insert into Manager (FirstName, LastName, Email, Phone, Address, City) values (@FirstName, @LastName, @Email, @Phone, @Address, @City) returning id;";
//             var result = await connection.ExecuteScalarAsync<int>(sql, new { Manager.FirstName, Manager.LastName, Manager.Email, Manager.Phone, Manager.Address, Manager.City});
//             Manager.Id = result;
//             return new Response<Manager>(Manager);
//         }
//         catch (Exception ex)
//         {
//             return new Response<Manager>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
//         }
//     }

//       public async Task<Response<Manager>> UpdateManager(Manager Manager)
//     {
//         try
//         {
//              using var connection = _context.CreateConnection();
//         {
//             string sql = $"update Manager set FirstName = @FirstName, LastName = @LastName, Email = @Email,Phone = @Phone,Address =  @Address, City = @City  where Id = @Id returning Id";
//             var response  = await connection.ExecuteScalarAsync<int>(sql, new{Manager.FirstName, Manager.LastName, Manager.Email, Manager.Phone,Manager.Address,Manager.City});
//             Manager.Id = response;
//             return new Response<Manager>(Manager);
//         }
//         }
//          catch (Exception ex)
//         {     
//            return new Response<Manager>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
//         }  
       
//     }

//     public async Task<Response<int>> DeleteManager(int id)
//     {
//         try
//         {
//              using var connection = _context.CreateConnection();
//         {
//             string sql = $"delete from Manager where Id = {id}";
//             var response  = await connection.ExecuteAsync(sql);
//             id = response;
//             return new Response<int>(response);
//         }
//         }
//          catch (Exception ex)
//         {
//            return new Response<int>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
//         }
//     } 
// }

using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LearnFrameworkMvc.Web.Controllers.Dapper
{
    public class HelloDupperController : Controller
    {
        public HelloDupperController()
        {

        }
        public IActionResult Index()
        {
            string ConString = @"Server=localhost;User=sa;Pwd=admin123;Database=LearnFrameworkMvc;TrustServerCertificate=True";
            string querystring = "SELECT * FROM Student where Name = @Name";
            var parameters = new { Name = "Tegar" };

            using var connection = new SqlConnection(ConString);
            var students = connection.Query<Student>(querystring, parameters).ToList();
            return Ok(students);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult RunSP()
        {
            string ConString = @"Server=localhost;User=sa;Pwd=admin123;Database=LearnFrameworkMvc;TrustServerCertificate=True";

            using (var connection = new SqlConnection(ConString))
            {
                //Set up DynamicParameters object to pass parameters  
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", 1);

                //Execute stored procedure and map the returned result to a Customer object  
                var customer = connection.QuerySingleOrDefault<Customer>("GetCustomerById", parameters, commandType: CommandType.StoredProcedure);
                return Ok();
            }
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}

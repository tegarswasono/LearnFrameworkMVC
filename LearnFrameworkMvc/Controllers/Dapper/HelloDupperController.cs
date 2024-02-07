using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LearnFrameworkMvc.Controllers.Dapper
{
    public class HelloDupperController : Controller
    {
        public IActionResult Index()
        {
            string ConString = @"Server=localhost;User=sa;Pwd=admin123;Database=LearnFrameworkMvc;TrustServerCertificate=True";
            string querystring = "SELECT * FROM Student where Name = @Name";
            var parameters = new { Name = "Tegar" };

            using var connection = new SqlConnection(ConString);
            var students = connection.Query<Student>(querystring, parameters).ToList();
            return Ok(students);
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LearnFrameworkMvc.Web.Controllers.LearnDapper
{
    public class AdonetController : Controller
    {
        public IActionResult Index()
        {
            string ConString = @"Server=localhost;User=sa;Pwd=admin123;Database=LearnFrameworkMvc;TrustServerCertificate=True";
            string querystring = "SELECT * FROM Student";

            SqlConnection con = new(ConString);
            con.Open();
            SqlCommand cmd = new(querystring, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }
            return Ok();
        }
    }
}

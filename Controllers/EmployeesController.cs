using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication3.Models.Employees;
using WebApplication3.Services.Employees;

namespace WebApplication3.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly string connetionString = "Data Source = DESKTOP; Initial Catalog = TimeManagment; Integrated Security = True;";
        public IActionResult Index()
        {
            using (var con = new SqlConnection(connetionString))
            {
                con.Open();
                var reponseScript = con.Query<EmployeeViewModel>("SELECT DocumentId, EmployNumber, CostCenter FROM Employees");
                con.Close();
                return View(reponseScript.ToList());
            }
        }

        public IActionResult EmployeesById(IFormCollection form)
        {
            using (var con = new SqlConnection(connetionString))
            {
                var id = form["id"].ToList();
                if (id.Count == 0) return View(new List<EmployeeViewModel>());
                con.Open();
                var reponseScript = con.Query<EmployeeViewModel>("EmployeesById @id", new { id = id[0] });
                con.Close();
                return View(reponseScript.ToList());
            }
        }
    }
}

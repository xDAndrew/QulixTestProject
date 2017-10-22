using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private SimpleObjectSet FormSet = new SimpleObjectSet("FormSet");
        private SimpleObjectSet SizeSet = new SimpleObjectSet("SizeSet");
        private SimpleObjectSet PositionSet = new SimpleObjectSet("PositionSet");
        private CompanySet Companies = new CompanySet("SELECT * FROM CompanySet");
        private EmployeeSet Employees = new EmployeeSet("SELECT * FROM EmployeeSet");

        public HomeController()
        {
            ViewBag.FormSet = FormSet;
            ViewBag.SizeSet = SizeSet;
            ViewBag.PositionSet = PositionSet;
            ViewBag.CompanySet = Companies;
            ViewBag.EmployeeSet = Employees;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCompanies()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            return View();
        }

        public ActionResult SetEmployee(int ID)
        {
            ViewBag.Id = ID;
            return View();
        }

        public ActionResult SetCompany(int ID)
        {
            ViewBag.Id = ID;
            return View();
        }

        public ActionResult SaveCompany(string id, string Name, int v1, int v2, string act)
        {
            if (act == "save")
            {
                if (int.Parse(id) == 0)
                {
                    var query = "INSERT INTO CompanySet (Name, Form_id, Size_id) VALUES (@name, @v1, @v2)";
                    var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
                    comm.Parameters.AddWithValue("@name", Name);
                    comm.Parameters.AddWithValue("@v1", v1);
                    comm.Parameters.AddWithValue("@v2", v2);
                    comm.ExecuteNonQuery();
                }
                else
                {
                    var query = "UPDATE CompanySet SET Name = @name, Form_id=@v1, Size_id=@v2 WHERE Id=@id";
                    var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
                    comm.Parameters.AddWithValue("@id", int.Parse(id));
                    comm.Parameters.AddWithValue("@name", Name);
                    comm.Parameters.AddWithValue("@v1", v1);
                    comm.Parameters.AddWithValue("@v2", v2);
                    comm.ExecuteNonQuery();
                }
            }

            return Redirect("../Home/GetCompanies");
        }

        public ActionResult SaveEmployee(string id, string Name, string surname, string lastname, string date, int v1, int v2, string act)
        {
            if (act == "save")
            {
                if (int.Parse(id) == 0)
                {
                    var query = "INSERT INTO EmployeeSet (Name, Surname, Lastname, Date, Position_id, Company_id) VALUES (@name, @surname, @lastname, @date, @v1, @v2)";
                    var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
                    comm.Parameters.AddWithValue("@name", Name);
                    comm.Parameters.AddWithValue("@surname", surname);
                    comm.Parameters.AddWithValue("@lastname", lastname);
                    comm.Parameters.AddWithValue("@date", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                    comm.Parameters.AddWithValue("@v1", v1);
                    comm.Parameters.AddWithValue("@v2", v2);
                    comm.ExecuteNonQuery();
                }
                else
                {
                    var query = "UPDATE EmployeeSet SET Name=@name, Surname=@surname, Lastname=@Lastname, Date=@date, Position_id=@v1, Company_id=@v2 WHERE Id=@id";
                    var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
                    comm.Parameters.AddWithValue("@id", int.Parse(id));
                    comm.Parameters.AddWithValue("@name", Name);
                    comm.Parameters.AddWithValue("@surname", surname);
                    comm.Parameters.AddWithValue("@lastname", lastname);
                    comm.Parameters.AddWithValue("@date", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                    comm.Parameters.AddWithValue("@v1", v1);
                    comm.Parameters.AddWithValue("@v2", v2);
                    comm.ExecuteNonQuery();
                }
            }

            return Redirect("../Home/GetEmployees");
        }

        public ActionResult DeleteCompany(int ID)
        {
            var query = "DELETE FROM dbo.CompanySet WHERE Id=@id";
            var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
            comm.Parameters.AddWithValue("@id", ID);
            comm.ExecuteNonQuery();

            return Redirect("../Home/GetCompanies");
        }

        public ActionResult DeleteEmployee(int ID)
        {
            var query = "DELETE FROM dbo.EmployeeSet WHERE Id=@id";
            var comm = new SqlCommand(query, DBContext.GetInstance().Connection);
            comm.Parameters.AddWithValue("@id", ID);
            comm.ExecuteNonQuery();

            return Redirect("../Home/GetEmployees");
        }

        [HttpPost]
        public ActionResult CancelEmployee()
        {
            return Redirect("../Home/GetEmployees");
        }

        [HttpPost]
        public ActionResult CancelCompany()
        {
            return Redirect("../Home/GetCompanies");
        }
    }
}
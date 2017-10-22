using System;
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

        public HomeController()
        {
            DBContext.GetInstance().Init();
            ViewBag.FormSet = FormSet;
            ViewBag.SizeSet = SizeSet;
            ViewBag.PositionSet = PositionSet;
            ViewBag.CompanySet = Companies;
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

        public ActionResult MyAction(string id, string Name, int v1, int v2, string act)
        {
            if (act == "save")
            {
                int ind = int.Parse(id);
                if (ind == 0)
                {
                    DBContext.GetInstance().MakeEmptyQuery("INSERT INTO CompanySet (Name, Form_id, Size_id) VALUES (N'" + Name + "', " + v1 + ", " + v2 + ")");
                }
                else
                {
                    DBContext.GetInstance().MakeEmptyQuery("UPDATE CompanySet SET Name = N'" + Name + "', Form_id=" + v1 + ", Size_id=" + v2 + " WHERE Id=" + ind.ToString());
                }
            }

            return Redirect("../Home/GetCompanies");
        }

        public ActionResult Delete(int ID)
        {
            DBContext.GetInstance().MakeEmptyQuery("DELETE FROM dbo.CompanySet WHERE Id = " + ID.ToString());
            return Redirect("../Home/GetCompanies");
        }
    }
}
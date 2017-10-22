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

        public HomeController()
        {
            DBContext.GetInstance().Init();
            ViewBag.FormSet = FormSet;
            ViewBag.SizeSet = SizeSet;
            ViewBag.PositionSet = PositionSet;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCompanies()
        {
            var list = new List<Company>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Company());
            }

            ViewBag.myList = list;

            return View();
        }

        public ActionResult GetEmployees()
        {
            var list = new List<Employee>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Employee());
            }

            ViewBag.myList = list;

            return View();
        }

        public ActionResult SetEmployee(int ID)
        {
            ViewBag.Id = ID;
            return View();
        }

        [HttpGet]
        public ActionResult SetCompany(int ID)
        {
            ViewBag.Id = ID;
            return View();
        }

        public ActionResult MyAction(string Name, int v1, int v2, string act)
        {
            if (act == "save")
            {
                return Redirect("../Home/Index");
            }

            return Redirect("../Home/GetCompanies");
        }

    }
}
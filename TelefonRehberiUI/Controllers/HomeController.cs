using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberiDAL.EfDal.Concrete;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            List<Employee> employees = EfEmployeeDal.CreateAsSingleton().GetAll();
            ViewBag.employees = employees;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
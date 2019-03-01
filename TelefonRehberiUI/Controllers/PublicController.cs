using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonReberiBLL.Abstract;
using TelefonRehberiDAL.EfDal.Concrete;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiUI.Controllers
{
    public class PublicController : Controller
    {
        IEmployeeService _employeeService;

        public PublicController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult ListOfEmployees()
        {
            List<Employee> employees = _employeeService.GetAll();
            return View(employees);
        }

        public ActionResult DetailOfEmployee(int _id)
        {
            EmployeeWithDpName employee = _employeeService.GetEmployeeWithDpName(_id);
            return View(employee);
        }
    }
}
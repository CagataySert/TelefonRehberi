using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonReberiBLL.Abstract;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiUI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        IEmployeeService _employeeService;
        IManagerService _managerService;
        IDepartmentService _departmentService;
        public AdminController(IEmployeeService employeeService,IManagerService managerService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _managerService = managerService;
            _departmentService = departmentService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public bool SaveLoginForm(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "123123")
            {
                Session["CheckUserRole"] = "Admin";
                return true;
            }
            return false;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }

        public ActionResult GetAllEmployees()
        {
            List<Employee> employees = _employeeService.GetAll();
            return View(employees);
        }

        public ActionResult DetailOfEmployee(int _id)
        {
            EmployeeWithDpName employee = _employeeService.GetEmployeeWithDpName(_id);
            return View(employee);
        }

        public bool DeleteEmployee(int  _id)
        {
            bool isDeleted = _employeeService.Delete(_id);
            return isDeleted;
        }

        public ActionResult AddNewEmployee()
        {
            List<Department> departments = _departmentService.GetAll();           
            ViewBag.departments = departments;

            return View();
        }        

        public JsonResult GetManagers(int departmentId)
        {
            List<Manager> managers = _managerService.GetAll(m => m.DepartmentId == departmentId);
            return Json(managers,JsonRequestBehavior.AllowGet);
        }

        public bool SaveNewEmployeeForm(Employee employee)
        {
            bool isAdded = _employeeService.AddOrUpdate(employee);
            return isAdded;
        }

        public ActionResult DepartmentControl()
        {
            List<Department> departments = _departmentService.GetAll();
            return View(departments);
        }

        public ActionResult AddNewDepartment()
        {
            return View();
        }

        public bool SaveNewDepartment(Department department)
        {
            bool isUpdated = _departmentService.AddOrUpdate(department);
            return isUpdated;
        }

        public ActionResult UpdateDepartment(int _id)
        {
            ViewBag.departmentId = _id;
            return View();
        }

        public bool SaveUpdateDepartment(Department department)
        {
            bool isUpdated = _departmentService.AddOrUpdate(department);
            return isUpdated;
        }
        public bool DeleteDepartment(int _id)
        {
            bool isDeleted = _departmentService.Delete(_id);
            return isDeleted;
        }
    }
}
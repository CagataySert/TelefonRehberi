using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiDAL.EfDal.Abstract;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiDAL.EfDal.Concrete
{
    public class EfEmployeeDal : IEmployeeDal
    {
        private static EfEmployeeDal _efEmployeeDal;
        static Object _lockObject = new object();

        public EfEmployeeDal()
        {

        }

        public static EfEmployeeDal CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_efEmployeeDal == null)
                {
                    _efEmployeeDal = new EfEmployeeDal();
                }
            }
            return _efEmployeeDal;
        }

        TelefonRehberiContext context = new TelefonRehberiContext();

        public bool AddOrUpdate(Employee entity)
        {
            context.Employees.AddOrUpdate(entity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int _id)
        {
            Employee willBeDeletedEntity = context.Employees.Where(e => e.Id == _id).FirstOrDefault();
            context.Employees.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Employee Get(int _id)
        {
            return context.Employees.Where(e => e.Id == _id).FirstOrDefault();
        }

        public Employee Get(Expression<Func<Employee, bool>> predicate)
        {
            return context.Employees.Where(predicate).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> predicate)
        {
            return context.Employees.Where(predicate).ToList();
        }

        public EmployeeWithDpName GetEmployeeWithDpName(int _id)
        {
            Employee employee = context.Employees
                .Where(e => e.Id == _id)
                .FirstOrDefault();

            var dbModel = context.Departments
                                            .Where(d => d.Id == employee.DepartmentId)
                                            .Select(department => new 
                                            {
                                                DepartmentId = department.Id,
                                                DepartmentName = department.Name,
                                                employee.Id,
                                                employee.FirstName,
                                                employee.LastName,
                                                employee.PhoneNumber
                                            }).FirstOrDefault();

            EmployeeWithDpName employeeWithDpName = new EmployeeWithDpName();
            employeeWithDpName.DepartmentId = dbModel.DepartmentId;
            employeeWithDpName.DepartmentName = dbModel.DepartmentName;
            employeeWithDpName.Id = dbModel.Id;
            employeeWithDpName.FirstName = dbModel.FirstName;
            employeeWithDpName.LastName = dbModel.LastName;
            employeeWithDpName.PhoneNumber = dbModel.PhoneNumber;

            if (employeeWithDpName != null)
            {
                return employeeWithDpName;
            }
            return null;
        }
    }
}

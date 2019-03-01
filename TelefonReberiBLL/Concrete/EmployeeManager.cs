using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonReberiBLL.Abstract;
using TelefonRehberiDAL.EfDal.Abstract;
using TelefonRehberiEntities.Entities;

namespace TelefonReberiBLL.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public bool AddOrUpdate(Employee entity)
        {
            return _employeeDal.AddOrUpdate(entity);
        }

        public bool Delete(int _id)
        {
            return _employeeDal.Delete(_id);
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> predicate)
        {
            return _employeeDal.GetAll(predicate);
        }

        public Employee GetById(int _id)
        {
            return _employeeDal.Get(_id);
        }

        public Employee GetById(Expression<Func<Employee, bool>> predicate)
        {
            return _employeeDal.Get(predicate);
        }

        public EmployeeWithDpName GetEmployeeWithDpName(int _id)
        {
            return _employeeDal.GetEmployeeWithDpName(_id);
        }
    }
}

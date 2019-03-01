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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public bool AddOrUpdate(Department entity)
        {
            return _departmentDal.AddOrUpdate(entity);
        }

        public bool Delete(int _id)
        {
            return _departmentDal.Delete(_id);
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public List<Department> GetAll(Expression<Func<Department, bool>> predicate)
        {
            return _departmentDal.GetAll(predicate);
        }

        public Department GetById(int _id)
        {
            return _departmentDal.Get(_id);
        }

        public Department GetById(Expression<Func<Department, bool>> predicate)
        {
            return _departmentDal.Get(predicate);
        }
    }
}

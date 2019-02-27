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
    public class EfDepartmentDal : IDepartmentDal
    {
        private static EfDepartmentDal _efDepartmentDal;
        static Object _lockObject = new object();

        public EfDepartmentDal()
        {

        }

        public static EfDepartmentDal CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_efDepartmentDal == null)
                {
                    _efDepartmentDal = new EfDepartmentDal();
                }
            }
            return _efDepartmentDal;
        }

        TelefonRehberiContext context = new TelefonRehberiContext();

        public bool AddOrUpdate(Department entity)
        {
            context.Departments.AddOrUpdate(entity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int _id)
        {
            Department willBeDeletedEntity = context.Departments.Where(d => d.Id == _id).FirstOrDefault();
            context.Departments.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Department Get(int _id)
        {
            return context.Departments.Where(e => e.Id == _id).FirstOrDefault();
        }

        public Department Get(Expression<Func<Department, bool>> predicate)
        {
            return context.Departments.Where(predicate).FirstOrDefault();
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public List<Department> GetAll(Expression<Func<Department, bool>> predicate)
        {
            return context.Departments.Where(predicate).ToList();
        }
    }
}

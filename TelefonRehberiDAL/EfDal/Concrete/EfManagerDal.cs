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
    public class EfManagerDal : IManagerDal
    {
        private static EfManagerDal _efManagerDal;
        static Object _lockObject = new object();

        public EfManagerDal()
        {

        }

        public static EfManagerDal CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_efManagerDal == null)
                {
                    _efManagerDal = new EfManagerDal();
                }
            }
            return _efManagerDal;
        }

        TelefonRehberiContext context = new TelefonRehberiContext();

        public bool AddOrUpdate(Manager entity)
        {
            context.Managers.AddOrUpdate(entity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int _id)
        {
            Manager willBeDeletedEntity = context.Managers.Where(m => m.Id == _id).FirstOrDefault();
            context.Managers.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Manager Get(int _id)
        {
            return context.Managers.Where(e => e.Id == _id).FirstOrDefault();
        }

        public Manager Get(Expression<Func<Manager, bool>> predicate)
        {
            return context.Managers.Where(predicate).FirstOrDefault();
        }

        public List<Manager> GetAll()
        {
            return context.Managers.ToList();
        }

        public List<Manager> GetAll(Expression<Func<Manager, bool>> predicate)
        {
            return context.Managers.Where(predicate).ToList();
        }
    }
}

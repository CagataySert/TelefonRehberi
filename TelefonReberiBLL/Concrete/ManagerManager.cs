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
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;
        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public bool AddOrUpdate(Manager entity)
        {
            return _managerDal.AddOrUpdate(entity);
        }

        public bool Delete(int _id)
        {
            return _managerDal.Delete(_id);
        }

        public List<Manager> GetAll()
        {
            return _managerDal.GetAll();
        }

        public List<Manager> GetAll(Expression<Func<Manager, bool>> predicate)
        {
            return _managerDal.GetAll(predicate);
        }

        public Manager GetById(int _id)
        {
            return _managerDal.Get(_id);
        }

        public Manager GetById(Expression<Func<Manager, bool>> predicate)
        {
            return _managerDal.Get(predicate);
        }
    }
}

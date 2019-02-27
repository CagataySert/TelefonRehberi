using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiDAL.EfDal.Abstract
{
    public interface IRepositoryDal<T> where T: class, new()
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(int _id);
        T Get(Expression<Func<T, bool>> predicate);
        bool AddOrUpdate(T entity);
        bool Delete(int _id);
    }
}

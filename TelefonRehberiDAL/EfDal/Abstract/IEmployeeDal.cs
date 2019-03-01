using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiDAL.EfDal.Abstract
{
    public interface IEmployeeDal:IRepositoryDal<Employee>
    {
        EmployeeWithDpName GetEmployeeWithDpName(int _id);
    }
}

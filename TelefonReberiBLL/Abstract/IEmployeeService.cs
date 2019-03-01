using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiEntities.Entities;

namespace TelefonReberiBLL.Abstract
{
    public interface IEmployeeService:IGenericService<Employee>
    {
        EmployeeWithDpName GetEmployeeWithDpName(int _id);
    }
}

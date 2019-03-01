using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiEntities.Entities
{
    public class EmployeeWithDpName:Employee
    {
        public string DepartmentName { get; set; }
    }
}

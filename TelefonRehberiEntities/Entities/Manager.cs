using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiEntities.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }

        public int DepartmentId { get; set; }
    }
}

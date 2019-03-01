using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiEntities.Entities;

namespace TelefonRehberiDAL.EfDal.Concrete
{
    public class TelefonRehberiContext:DbContext
    {
        public TelefonRehberiContext():base("name=TelefonRehberiConnectionString")
        {
            Database.SetInitializer<TelefonRehberiContext>(new TelefonRehberiInitializer<TelefonRehberiContext>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        private class TelefonRehberiInitializer<T> : DropCreateDatabaseIfModelChanges<TelefonRehberiContext>
        {
            protected override void Seed(TelefonRehberiContext context)
            {
                List<Employee> employees = new List<Employee>();
                employees.Add(new Employee() { Id = 1, FirstName = "Çağatay", LastName = "Sert", PhoneNumber = "05376526222", DepartmentId = 1 });
                employees.Add(new Employee() { Id = 2, FirstName = "Ahmet", LastName = "Kaplan", PhoneNumber = "05376526233", DepartmentId = 1 });
                employees.Add(new Employee() { Id = 3, FirstName = "Mehmet", LastName = "Kara", PhoneNumber = "05376526244", DepartmentId = 1 });
                employees.Add(new Employee() { Id = 4, FirstName = "Mustafa", LastName = "Aslan", PhoneNumber = "05376526255", DepartmentId = 2 });
                employees.Add(new Employee() { Id = 5, FirstName = "Okan", LastName = "Demir", PhoneNumber = "05376526266", DepartmentId = 2 });
                employees.Add(new Employee() { Id = 6, FirstName = "Oktay", LastName = "Özdemir", PhoneNumber = "05376526277", DepartmentId = 2 });
                employees.Add(new Employee() { Id = 7, FirstName = "Ali", LastName = "Öz", PhoneNumber = "05376526288", DepartmentId = 3 });
                employees.Add(new Employee() { Id = 8, FirstName = "Veli", LastName = "Kafes", PhoneNumber = "05376526299", DepartmentId = 3 });
                employees.Add(new Employee() { Id = 9, FirstName = "Seyhan", LastName = "Çivril", PhoneNumber = "05376526211", DepartmentId = 3 });

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }

                List<Manager> managers = new List<Manager>();
                managers.Add(new Manager() { Id = 1, FirstName = "Burhan", LastName = "Altıntop", DepartmentId = 1 });
                managers.Add(new Manager() { Id = 2, FirstName = "Cem", LastName = "Aslan", DepartmentId = 2 });
                managers.Add(new Manager() { Id = 3, FirstName = "Tanrıverdi", LastName = "Kale", DepartmentId = 3 });

                foreach (var manager in managers)
                {
                    context.Managers.Add(manager);
                }

                List<Department> departments = new List<Department>();
                departments.Add(new Department() { Id = 1, Name = "IT" });
                departments.Add(new Department() { Id = 2, Name = "HumanResources" });
                departments.Add(new Department() { Id = 3, Name = "Marketing" });

                foreach (var department in departments)
                {
                    context.Departments.Add(department);
                }

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}

using System.Data.Entity;
using EmployeesTest.Data.Models;

namespace EmployeesTest.Data.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=conn") { }

        public DbSet<Employee> Employees { get; set; }
    }
}

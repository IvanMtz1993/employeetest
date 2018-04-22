using EmployeesTest.Data.Context;
using EmployeesTest.Data.Interfaces;
using EmployeesTest.Data.Models;

namespace EmployeesTest.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public EmployeeContext EmpleContext => Context as EmployeeContext;
    }
}

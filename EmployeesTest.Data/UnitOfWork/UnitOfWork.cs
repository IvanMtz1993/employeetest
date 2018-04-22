using EmployeesTest.Data.Context;
using EmployeesTest.Data.Interfaces;
using EmployeesTest.Data.Repositories;

namespace EmployeesTest.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext _context;

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(_context);
        }

        public IEmployeeRepository Employee { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

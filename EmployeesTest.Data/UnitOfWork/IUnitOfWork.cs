using System;
using EmployeesTest.Data.Interfaces;

namespace EmployeesTest.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        int SaveChanges();
    }
}
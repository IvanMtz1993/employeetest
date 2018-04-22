using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeesTest.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity obj);
    }
}
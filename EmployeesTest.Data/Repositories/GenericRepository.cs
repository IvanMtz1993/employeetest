using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EmployeesTest.Data.Context;
using EmployeesTest.Data.Interfaces;

namespace EmployeesTest.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EmployeeContext Context;

        public GenericRepository(EmployeeContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
        }
    }
}

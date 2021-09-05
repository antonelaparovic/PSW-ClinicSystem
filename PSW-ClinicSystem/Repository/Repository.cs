using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PSW_ClinicSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context;
        
        public DataDbContext DataDbContext
        {
            get { return Context as DataDbContext; }
        }
        public Repository(DataDbContext context)  // DbContextOptions ??
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}

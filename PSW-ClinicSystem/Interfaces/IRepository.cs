using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace PSW_ClinicSystem.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);  
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);    // bool
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);

        void Save();
    }
}

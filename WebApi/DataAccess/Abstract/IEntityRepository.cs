using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models.Entities;
using WebApi.Utilities;

namespace WebApi.DataAccess
{
    public interface IEntityRepository<T>
        where T: class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

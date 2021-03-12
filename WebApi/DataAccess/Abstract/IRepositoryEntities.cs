using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
    public interface IRepositoryEntities<T>
        where T: class, new()
    {
        Task<List<T>> GetAllAsync();
        
        T Get(Guid guidId);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

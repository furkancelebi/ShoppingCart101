using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        void Add(TKey id, TEntity entity);
        void Update(TKey id, TEntity entity);
        void Delete(TKey id);
        List<TEntity> GetList();
        TEntity Find(TKey id);
    }
}
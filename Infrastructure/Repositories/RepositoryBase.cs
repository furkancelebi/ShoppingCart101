using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
       where TEntity : class
    {
        Dictionary<TKey, TEntity> _listEntities = new Dictionary<TKey, TEntity>();

        public void Add(TKey id, TEntity entity)
        {
            _listEntities.Add(id, entity);
        }

        public void Delete(TKey id)
        {
            _listEntities.Remove(id);
        }

        public TEntity Find(TKey id)
        {
            return _listEntities[id];
        }

        public List<TEntity> GetList()
        {
            return _listEntities.Values.ToList();
        }

        public void Update(TKey id, TEntity entity)
        {
            _listEntities[id] = entity;
        }
    }
}

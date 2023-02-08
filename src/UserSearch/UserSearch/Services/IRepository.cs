using System.Collections.Generic;

namespace UserSearch.Services
{
    public interface IRepository<TEntity, TID>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(TID id);
        bool TryGetByID(TID id, out TEntity entity);

        void Insert(TEntity entity);

        bool TryInsert(TEntity entity);
        void Update(TEntity entity);
        bool TryUpdate(TEntity entity);

        void Delete(TID id);

        bool TryDelete(TID id, out TEntity entity);
        void Save();
    }
}

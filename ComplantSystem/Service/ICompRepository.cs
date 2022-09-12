using System.Collections.Generic;

namespace ComplantSystem.Service
{
    public interface ICompRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(string id, string Keyword);
        void Delete(string id);
        void Add(TEntity entity);
        void Update(string Id, TEntity entity);
        public List<TEntity> Search(string Id, string KeyTerm);
    }
}

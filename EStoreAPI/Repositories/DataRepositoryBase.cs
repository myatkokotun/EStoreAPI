using EStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EStoreAPI.Repositories
{
    public abstract class DataRepositoryBase<T> where T : class, new()
    {
        protected abstract T AddEntity(EstoreContext entityContext, T entity);
        protected abstract T UpdateEntity(EstoreContext entityContext, T entity);
        protected abstract IQueryable<T> GetQueryable();
        protected abstract T RemoveEntity(EstoreContext entityContext, T entity);


        public async Task<T> Add(T entity)
        {
            using (EstoreContext entityContext = new EstoreContext())
            {
                T addedEntity = AddEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return addedEntity;
            }
        }

        public async Task<T> update(T entity)
        {
            using (EstoreContext entityContext = new EstoreContext())
            {
                T upentity = UpdateEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return upentity;
            }
        }

        public IQueryable<T> GetDataSet()
        {
            return GetQueryable().AsQueryable().AsNoTracking();
        }

        public async Task<T> Remove(T entity)
        {
            using (EstoreContext entityContext = new EstoreContext())
            {
                T reventity = RemoveEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return reventity;
            }
        }
    }
}

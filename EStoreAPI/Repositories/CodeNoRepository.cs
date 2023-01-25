using EStoreAPI.Models;

namespace EStoreAPI.Repositories
{
    public class CodeNoRepository : DataRepositoryBase<TbCode>
    {
        public EstoreContext _context;
        public CodeNoRepository(EstoreContext context)
        {
            _context = context;
        }
        protected override TbCode AddEntity(EstoreContext entityContext, TbCode entity)
        {
            return entityContext.TbCodes.Add(entity).Entity;
        }


        protected override IQueryable<TbCode> GetQueryable()
        {
            return _context.TbCodes;
        }

        protected override TbCode RemoveEntity(EstoreContext entityContext, TbCode entity)
        {
            return entityContext.TbCodes.Remove(entity).Entity;
        }

        protected override TbCode UpdateEntity(EstoreContext entityContext, TbCode entity)
        {
            return entityContext.TbCodes.Update(entity).Entity;
        }
    }
}

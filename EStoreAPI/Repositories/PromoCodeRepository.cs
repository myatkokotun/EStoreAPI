using EStoreAPI.Models;

namespace EStoreAPI.Repositories
{
    public class PromoCodeRepository : DataRepositoryBase<TbPromoCode>
    {
        public EstoreContext _context;
        public PromoCodeRepository(EstoreContext context)
        {
            _context = context;
        }
        protected override TbPromoCode AddEntity(EstoreContext entityContext, TbPromoCode entity)
        {
            return entityContext.TbPromoCodes.Add(entity).Entity;
        }


        protected override IQueryable<TbPromoCode> GetQueryable()
        {
            return _context.TbPromoCodes;
        }

        protected override TbPromoCode RemoveEntity(EstoreContext entityContext, TbPromoCode entity)
        {
            return entityContext.TbPromoCodes.Remove(entity).Entity;
        }

        protected override TbPromoCode UpdateEntity(EstoreContext entityContext, TbPromoCode entity)
        {
            return entityContext.TbPromoCodes.Update(entity).Entity;
        }
    }
}

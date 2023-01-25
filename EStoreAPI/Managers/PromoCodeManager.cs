using EStoreAPI.Helpers;
using EStoreAPI.Models;
using EStoreAPI.Repositories;
using EStoreAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EStoreAPI.Managers
{
    public class PromoCodeManager
    {
        public async Task<string> UpSertPromoCode(int EVid = 0, string Phone = null)
        {
            using (EstoreContext ctx = new EstoreContext())
            {
                PromoCodeRepository pcrepo = new PromoCodeRepository(ctx);
                CodeNoRepository cnrepo = new CodeNoRepository(ctx);
                TbPromoCode updatedEntity = null;
                int ranNumber = (new Random()).Next(1, 99);
                TbCode codeobj = cnrepo.GetDataSet().Where(s => s.Isredeem != true).OrderBy(s => s.Id).Take(ranNumber).LastOrDefault();
                string pcode = "promo" + codeobj.Codeno;
                TbPromoCode promocode = new TbPromoCode();
                promocode.Evoucherid = EVid;
                promocode.Phoneno = Phone;
                promocode.Promocode = pcode;
                promocode.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
                if (promocode.Id == 0)
                {
                    updatedEntity = await pcrepo.Add(promocode);
                }
                else
                {
                    updatedEntity = await pcrepo.update(promocode);
                }
                if (updatedEntity != null)
                {
                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }
        }

        public async Task<TbPromoCode> DetailPromoCode(int ID)
        {
            using (EstoreContext ctx = new EstoreContext())
            {
                PromoCodeRepository pcrepo = new PromoCodeRepository(ctx);
                TbPromoCode result = await pcrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<PagedListModel<TbPromoCode>> PromoCodeList(int page = 1, int pageSize = 10)
        {
            using (EstoreContext ctx = new EstoreContext())
            {
                PromoCodeRepository pcrepo = new PromoCodeRepository(ctx);
                IQueryable<TbPromoCode> _pclist = pcrepo.GetDataSet();
                #region paging
                var totalCount = _pclist.Select(c => c.Id).Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var result = _pclist.Skip(pageSize * (page - 1))
                                     .Take(pageSize);
                PagedListModel<TbPromoCode> model = new PagedListModel<TbPromoCode>()
                {
                    TotalCount = totalCount,
                    TotalPages = totalPages,
                    prevLink = "",
                    nextLink = "",
                    Results = result.ToList(),
                };
                #endregion
                return model;
            }
        }

        public async Task<string> DeletePromoCode(int ID)
        {
            using (EstoreContext ctx = new EstoreContext())
            {
                PromoCodeRepository pcrepo = new PromoCodeRepository(ctx);
                TbPromoCode result = await pcrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                if (result != null)
                {
                    pcrepo.Remove(result);
                    return "Success";
                }
                return "Fail";
            }
        }
    }
}

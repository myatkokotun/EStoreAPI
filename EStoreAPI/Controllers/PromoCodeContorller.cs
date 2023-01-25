using EStoreAPI.Managers;
using EStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PromoCodeContorller : ControllerBase
    {
        PromoCodeManager pcmgr = new PromoCodeManager();
        CodeNoManager cnmgr=new CodeNoManager();

        [HttpGet]
        public async Task<IActionResult> GetPromoCodeList()
        {
            var pmlist = await pcmgr.PromoCodeList();
            return Ok(pmlist);
        }

        [HttpGet]
        public async Task<IActionResult> GetPromoCodeObj(int id)
        {
            TbPromoCode obj = await pcmgr.DetailPromoCode(id);
            if (obj == null) return BadRequest();
            return Ok(obj);
        }

        [HttpGet]
        public async Task<IActionResult> UpSertPromoCode(int EVid=0, string Phone=null)
        {
            string status = await pcmgr.UpSertPromoCode(EVid, Phone);
            if (status == "Fail") return NotFound();
            return Ok(status);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePromoCode(int id)
        {
            string status = await pcmgr.DeletePromoCode(id);
            return Ok(status);
        }

        [HttpGet]
        public async Task<IActionResult> GenerateCodeNo()
        {
            var status = await cnmgr.GenerateCodeNo();
            return Ok(status);
        }
    }
}

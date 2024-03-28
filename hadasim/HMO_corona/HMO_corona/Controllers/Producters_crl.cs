using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Producters_crl : ControllerBase
    {
        IProducter_bll producter;
        public Producters_crl(IProducter_bll pd)
        {
            producter = pd;
        }

        [HttpGet("GetAllProducters")]
        public ActionResult<List<Producter_dto>> GetProducters()
        {
            return Ok(producter.GetAll());
        }

        [HttpGet("GetProducter/{id}")]
        public ActionResult<List<Producter_dto>> GetProducter(int id)
        {
            return Ok(producter.Get(id));
        }

        [HttpDelete("DeleteProducter/{id}")]
        public ActionResult<List<Producter_dto>> DeleteProducter(int id)
        {
            return Ok(producter.Delete(id));
        }

        [HttpPost("CreateProducter")]
        public ActionResult<List<Producter_dto>> CreateProducter(Producter_dto prd)
        {
            return Ok(producter.Create(prd));
        }

        [HttpPut("UpdateProducter")]
        public ActionResult<List<Producter_dto>> UpdateProducter(Producter_dto prd)
        {
            return Ok(producter.Update(prd));
        }
    }
}

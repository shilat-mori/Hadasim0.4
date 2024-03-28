using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Serologions_crl : ControllerBase
    {
        ISerologion_bll srologi;
        public Serologions_crl(ISerologion_bll srl)
        {
            srologi = srl;
        }

        [HttpGet("GetAllSerologions")]
        public ActionResult<List<Serologion_dto>> GetPatientssrologies()
        {
            return Ok(srologi.GetAll());
        }

        [HttpGet("GetSerologion/{id}")]
        public ActionResult<List<Serologion_dto>> GetSerologion(string id)
        {
            return Ok(srologi.Get(id));
        }

        [HttpDelete("DeleteSerologion/{id}")]
        public ActionResult<List<Serologion_dto>> DeleteSerologion(string id)
        {
            return Ok(srologi.Delete(id));
        }

        [HttpPost("CreateSerologion")]
        public ActionResult<List<Serologion_dto>> CreateSerologion(Serologion_dto srl)
        {
            return Ok(srologi.Create(srl));
        }

        [HttpPut("UpdateSerologion")]
        public ActionResult<List<Serologion_dto>> UpdateSerologion(Serologion_dto srl)
        {
            return Ok(srologi.Update(srl));
        }

        [HttpGet("GetLastMonthSicks")]
        public ActionResult<List<int>> GetLastMonthSicks()
        {
            return Ok(srologi.LastMonthSicks());
        }

        [HttpGet("GetUnVaccinated")]
        public ActionResult<List<int>> GetUnVaccinated()
        {
            return Ok(srologi.Unvaccinated());
        }
    }
}

using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaVaccines_crl : ControllerBase
    {
        ICoronaVaccine_bll corona_vaccine;
        public CoronaVaccines_crl(ICoronaVaccine_bll cv)
        {
            corona_vaccine = cv;
        }

        [HttpGet("GetAllCoronaVaccines")]
        public ActionResult<List<CoronaVaccine_dto>> GetCoronaVaccines()
        {
            return Ok(corona_vaccine.GetAll());
        }

        [HttpGet("GetCoronaVaccine/{id}")]
        public ActionResult<List<CoronaVaccine_dto>> GetCoronaVaccine(string id)
        {
            return Ok(corona_vaccine.Get(id));
        }

        [HttpDelete("DeleteCoronaVaccine/{id}")]
        public ActionResult<List<CoronaVaccine_dto>> DeleteCoronaVaccine(string id)
        {
            return Ok(corona_vaccine.Delete(id));
        }

        [HttpPost("CreateCoronaVaccine")]
        public ActionResult<List<CoronaVaccine_dto>> CreateCoronaVaccine(CoronaVaccine_dto cv)
        {
            return Ok(corona_vaccine.Create(cv));
        }

        [HttpPut("UpdateCoronaVaccine")]
        public ActionResult<List<CoronaVaccine_dto>> UpdateCoronaVaccine(CoronaVaccine_dto cv)
        {
            return Ok(corona_vaccine.Update(cv));
        }
        
    }
}

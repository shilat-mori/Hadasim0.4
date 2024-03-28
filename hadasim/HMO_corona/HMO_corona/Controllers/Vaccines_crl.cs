using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Vaccines_crl : ControllerBase
    {
        IVaccine_bll vaccine;
        public Vaccines_crl(IVaccine_bll vc)
        {
            vaccine = vc;
        }

        [HttpGet("GetAllVaccines")]
        public ActionResult<List<Vaccine_dto>> GetVaccines()
        {
            return Ok(vaccine.GetAll());
        }

        [HttpGet("GetVaccine/{id}")]
        public ActionResult<List<Vaccine_dto>> GetVaccine(int id)
        {
            return Ok(vaccine.Get(id));
        }

        [HttpDelete("DeleteVaccine/{id}")]
        public ActionResult<List<Vaccine_dto>> DeleteVaccine(int id)
        {
            return Ok(vaccine.Delete(id));
        }

        [HttpPost("CreateVaccine")]
        public ActionResult<List<Vaccine_dto>> CreateVaccine(Vaccine_dto vc)
        {
            return Ok(vaccine.Create(vc));
        }

        [HttpPut("UpdateVaccine")]
        public ActionResult<List<Vaccine_dto>> UpdateVaccine(Vaccine_dto vc)
        {
            return Ok(vaccine.Update(vc));
        }
    }
}

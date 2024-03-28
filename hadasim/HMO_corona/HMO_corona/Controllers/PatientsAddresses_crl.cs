using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsAddresses_crl : ControllerBase
    {
        IPatientAddress_bll address;
        public PatientsAddresses_crl(IPatientAddress_bll ad)
        {
            address = ad;
        }

        [HttpGet("GetAllPatientsAddresses")]
        public ActionResult<List<PatientAddress_dto>> GetPatientsAddresses()
        {
            return Ok(address.GetAll());
        }

        [HttpGet("GetPatientAddress/{id}")]
        public ActionResult<List<PatientAddress_dto>> GetPatientAddress(int id)
        {
            return Ok(address.Get(id));
        }

        [HttpDelete("DeletePatientAddress/{id}")]
        public ActionResult<List<PatientAddress_dto>> DeletePatientAddress(int id)
        {
            return Ok(address.Delete(id));
        }

        [HttpPost("CreatePatientAddress")]
        public ActionResult<List<PatientAddress_dto>> CreatePatientAddress(PatientAddress_dto pt)
        {
            return Ok(address.Create(pt));
        }

        [HttpPut("UpdatePatientAddress")]
        public ActionResult<List<PatientAddress_dto>> UpdatePatientAddress(PatientAddress_dto pt)
        {
            return Ok(address.Update(pt));
        }
    }
}

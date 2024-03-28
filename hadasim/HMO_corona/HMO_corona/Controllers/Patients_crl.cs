using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_corona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Patients_crl : ControllerBase
    {
        IPatient_bll patient;
        public Patients_crl(IPatient_bll pt)
        {
            patient = pt;
        }

        [HttpGet("GetAllPatients")]
        public ActionResult<List<Patient_dto>> GetPatients()
        {
            return Ok(patient.GetAll());
        }

        [HttpGet("GetPatient/{id}")]
        public ActionResult<List<Patient_dto>> GetPatient(string id)
        {
            return Ok(patient.Get(id));
        }

        [HttpDelete("DeletePatient/{id}")]
        public ActionResult<List<Patient_dto>> DeletePatient(string id)
        {
            return Ok(patient.Delete(id));
        }

        [HttpPost("CreatePatient")]
        public ActionResult<List<Patient_dto>> CreatePatient(Patient_dto pt)
        {
            return Ok(patient.Create(pt));
        }

        [HttpPut("UpdatePatient")]
        public ActionResult<List<Patient_dto>> UpdatePatient(Patient_dto pt)
        {
            return Ok(patient.Update(pt));
        }
    }
}

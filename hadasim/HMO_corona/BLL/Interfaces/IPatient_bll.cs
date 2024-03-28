using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatient_bll:ICRUD_dto<Patient_dto, string>
    {
        //public string? Create(Patient_dto obj);
        //public bool Update(Patient_dto obj);
        //public bool Delete(string id);
        //public Patient_dto? Get(string id);
        //public List<Patient_dto> GetAll();
    }
}

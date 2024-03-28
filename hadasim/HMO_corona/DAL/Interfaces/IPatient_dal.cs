using DAL.CRUD;
using DAL.HMO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPatient_dal:ICRUD<Patient, string>
    {
    }
}

using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVaccine_bll: ICRUD_dto<Vaccine_dto, int>
    {
        //public int Create(Vaccine_dto obj);
        //public bool Update(Vaccine_dto obj);
        //public bool Delete(int id);
        //public Vaccine_dto? Get(int id);
        //public List<Vaccine_dto> GetAll();
    }
}

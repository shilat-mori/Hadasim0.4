using AutoMapper;
using BLL.Interfaces;
using DAL.HMO;
using DAL.Interfaces;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Func
{
    public class CoronaVaccine_bll: ICoronaVaccine_bll
    {
        IMapper mapper;
        ICoronaVaccine_dal dal_crud;
        IVaccine_dal vaccine_dal;
        public CoronaVaccine_bll(ICoronaVaccine_dal i_dal)
        {
            dal_crud = i_dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<CoronaVaccine_dto> GetAll()
        {
            return mapper.Map<List<CoronaVaccine>, List<CoronaVaccine_dto>>(dal_crud.GetAll());
        }

        public CoronaVaccine_dto? Get(string id)
        {
            return mapper.Map<CoronaVaccine?, CoronaVaccine_dto>(dal_crud.Get(id));
        }

        public string? Create(CoronaVaccine_dto cv)
        {
            cv.Vac1 = 0;
            cv.Vac2 = 0;
            cv.Vac3 = 0;
            cv.Vac4 = 0;
            return dal_crud.Create(mapper.Map<CoronaVaccine_dto, CoronaVaccine>(cv));
        }

        public bool Delete(string id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(CoronaVaccine_dto cv)
        {
            return dal_crud.Update(mapper.Map<CoronaVaccine_dto, CoronaVaccine>(cv));
        }
    }
}

using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.HMO;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Func
{
    public class Vaccine_bll : IVaccine_bll
    {
        IMapper mapper;
        IVaccine_dal dal_crud;
        public Vaccine_bll(IVaccine_dal i_dal)
        {
            dal_crud = i_dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<Vaccine_dto> GetAll()
        {
            return mapper.Map<List<Vaccine>, List<Vaccine_dto>>(dal_crud.GetAll());
        }

        public Vaccine_dto? Get(int id)
        {
            return mapper.Map<Vaccine?, Vaccine_dto>(dal_crud.Get(id));
        }

        public int Create(Vaccine_dto cv)
        {
            return dal_crud.Create(mapper.Map<Vaccine_dto, Vaccine>(cv));
        }

        public bool Delete(int id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(Vaccine_dto cv)
        {
            return dal_crud.Update(mapper.Map<Vaccine_dto, Vaccine>(cv));
        }
    }
}

using AutoMapper;
using DAL.Interfaces;
using BLL.Interfaces;
using DAL.HMO;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Func
{
    public class Producter_bll : IProducter_bll
    {
        IMapper mapper;
        IProducer_dal dal_crud;
        public Producter_bll(IProducer_dal i_dal)
        {
            dal_crud = i_dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<Producter_dto> GetAll()
        {
            return mapper.Map<List<Producer>, List<Producter_dto>>(dal_crud.GetAll());
        }

        public Producter_dto? Get(int id)
        {
            return mapper.Map<Producer?, Producter_dto>(dal_crud.Get(id));
        }

        public int Create(Producter_dto cv)
        {
            return dal_crud.Create(mapper.Map<Producter_dto, Producer>(cv));
        }

        public bool Delete(int id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(Producter_dto cv)
        {
            return dal_crud.Update(mapper.Map<Producter_dto, Producer>(cv));
        }
    }
}

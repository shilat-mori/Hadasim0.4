using AutoMapper;
using BLL.Interfaces;
using DAL.HMO;
using BLL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CRUD;

namespace BLL.Func
{
    public class PatientAddress_bll : IPatientAddress_bll
    {
        IMapper mapper;
        IPatientAddress_dal dal_crud;
        public PatientAddress_bll(IPatientAddress_dal i_dal)
        {
            dal_crud = i_dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<PatientAddress_dto> GetAll()
        {
            return mapper.Map<List<PatientAddress>, List<PatientAddress_dto>>(dal_crud.GetAll());
        }

        public PatientAddress_dto? Get(int id)
        {
            return mapper.Map<PatientAddress?, PatientAddress_dto>(dal_crud.Get(id));
        }

        public int Create(PatientAddress_dto cv)
        {
            return dal_crud.Create(mapper.Map<PatientAddress_dto, PatientAddress>(cv));
        }

        public bool Delete(int id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(PatientAddress_dto cv)
        {
            return dal_crud.Update(mapper.Map<PatientAddress_dto, PatientAddress>(cv));
        }

    }
}

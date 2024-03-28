using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using BLL.DTO;
using System;
using DAL.HMO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Func
{
    public class Patient_bll : IPatient_bll
    {
        IMapper mapper;
        IPatient_dal dal_crud;
        ICoronaVaccine_dal cv_dal;
        ISerologion_dal srl_dal;
        IPatientAddress_dal address_dal;

        public Patient_bll(IPatient_dal i_dal, ICoronaVaccine_dal dalcv, ISerologion_dal dalsrl, IPatientAddress_dal dalpa)
        {
            dal_crud = i_dal;
            cv_dal = dalcv;
            srl_dal = dalsrl;
            address_dal = dalpa;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<Patient_dto> GetAll()
        {
            return mapper.Map<List<Patient>, List<Patient_dto>>(dal_crud.GetAll());
        }

        public Patient_dto? Get(string id)
        {

            return mapper.Map<Patient?, Patient_dto>(dal_crud.Get(id));
        }

        public string? Create(Patient_dto pt)
        {
            PatientAddress_dto pa = new PatientAddress_dto();
            CoronaVaccine_dto cv = new CoronaVaccine_dto();
            Serologion_dto srl = new Serologion_dto();

            //יצירת חיסונים מקבילים
            cv.Id = pt.Id;
            cv.Vac1 = null;
            cv.Vac2 = null;
            cv.Vac3 = null;
            cv.Vac4 = null;
            CoronaVaccine cvdal = new CoronaVaccine();
            cvdal = mapper.Map<CoronaVaccine_dto, CoronaVaccine>(cv);

            string? res = cv_dal.Create(cvdal);
            if (res == null) return null;
            //יצירת סרולוגיה מקבילה
            srl.Id = pt.Id;
            srl.PositiveDate = null;
            srl.RecoveryDate = null;
            res = srl_dal.Create(mapper.Map < Serologion_dto, Serologion > (srl));
            if(res == null) return null;
            //יצירת כתובת
            if(address_dal.GetAll().FirstOrDefault(x=>x.Id == pt.AddressId)==null)
            {
                pt.AddressId = null;// ב"מ
            }
                

            return dal_crud.Create(mapper.Map<Patient_dto, Patient>(pt));
        }

        public bool Delete(string id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(Patient_dto cv)
        {
            return dal_crud.Update(mapper.Map<Patient_dto, Patient>(cv));
        }


    }
}

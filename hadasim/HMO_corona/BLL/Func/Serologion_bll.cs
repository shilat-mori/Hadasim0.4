using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.HMO;
using BLL.DTO;
using BLL.Func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BLL.Func
{
    public class Serologion_bll:ISerologion_bll
    {
        IMapper mapper;
        ISerologion_dal dal_crud;
        ICoronaVaccine_dal cv_crud;
        IPatient_dal pt_crud;
        public Serologion_bll(ISerologion_dal i_dal, ICoronaVaccine_dal cv_dal, IPatient_dal pt_dal)
        {
            cv_crud = cv_dal;
            dal_crud = i_dal;
            pt_crud = pt_dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            });
            mapper = config.CreateMapper();
        }

        public List<Serologion_dto> GetAll()
        {
            return mapper.Map<List<Serologion>, List<Serologion_dto>>(dal_crud.GetAll());
        }

        public Serologion_dto? Get(string id)
        {
            return mapper.Map<Serologion?, Serologion_dto>(dal_crud.Get(id));
        }

        public string? Create(Serologion_dto cv)
        {
            return dal_crud.Create(mapper.Map<Serologion_dto, Serologion>(cv));
        }

        public bool Delete(string id)
        {
            return dal_crud.Delete(id);
        }

        public bool Update(Serologion_dto cv)
        {
            return dal_crud.Update(mapper.Map<Serologion_dto, Serologion>(cv));
        }

        public List<int> LastMonthSicks()
        {
            //returns: list of number of sicks on each day last month
            DateTime currentDate = DateTime.Now;

            DateTime lastMonth = currentDate.AddMonths(-1);

            List<Serologion_dto> srl_table = GetAll();

            List<int> last_month_sicks = new int[DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month)].ToList();

            foreach (var Serologion in srl_table)
            {
                if (Serologion.PositiveDate != null && Serologion.PositiveDate.GetValueOrDefault().Month == (DateTime.Now.Month-1))
                    last_month_sicks[Serologion.PositiveDate.GetValueOrDefault().Day - 1]++;
            }
            return last_month_sicks;
        }

        public int Unvaccinated()
        {
            //returns: how many unVaccines patients are there
            int vaccinated = cv_crud.GetAll().Where(x=> x.Vac1 != null || x.Vac2 != null || x.Vac3 != null || x.Vac4 != null ).Count();
            int all = pt_crud.GetAll().Count();
            return all - vaccinated;
        }
    }
}

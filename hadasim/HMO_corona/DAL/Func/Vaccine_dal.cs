using DAL.HMO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class Vaccine_dal:IVaccine_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(Vaccine vaccine)
        {
            return (ValidationTest.PastDate(vaccine.VacDate)|| ValidationTest.FutureDate(vaccine.VacDate))
                && (dbo.Producers.FirstOrDefault(x=>x.Id==vaccine.Producer)!=null);
        }
        public int Create(Vaccine obj)
        {
            //if (dbo.Vaccines.FirstOrDefault(x => x.Id == obj.Id) != null)
            //    return -1;
            obj.Id = 0;
            try
            {
                dbo.Vaccines.Add(obj);
                dbo.SaveChanges();
                return obj.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public bool Delete(int id)
        {
            Vaccine? pt = dbo.Vaccines.FirstOrDefault(x => x.Id == id);
            if (pt == null)
                return false;

            try
            {
                dbo.Vaccines.Remove(pt);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Vaccine? Get(int id)
        {
            return dbo.Vaccines.FirstOrDefault(x => x.Id == id);
        }

        public List<Vaccine> GetAll()
        {
            return dbo.Vaccines.ToList();
        }

        public bool Update(Vaccine obj)
        {
            Vaccine? pt = dbo.Vaccines.FirstOrDefault(x => x.Id == obj.Id);
            if (pt == null)
                return false;
            if(Valid(obj))
            try
            {
                pt.VacDate = obj.VacDate;
                pt.Producer = obj.Producer;
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}

using DAL.HMO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class Serologion_dal:ISerologion_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(Serologion serologion)
        {
            return ValidationTest.PastDate(serologion.PositiveDate)
                && (ValidationTest.FutureDate(serologion.RecoveryDate)|| ValidationTest.PastDate(serologion.RecoveryDate));
        }
        public string? Create(Serologion obj)
        {
            Serologion? srl = dbo.Serologions.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (srl != null)
            {
                if(srl.Status == false)
                {
                    srl.Status = true;
                    dbo.SaveChanges();
                }
                return obj.Id;
            }

            if(Valid(obj))
            try
            {
                obj.Status = true;
                dbo.Serologions.Add(obj);
                dbo.SaveChanges();
                return obj.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public bool Delete(string id)
        {
            Serologion? srl = dbo.Serologions.FirstOrDefault(x => x.Id.Equals(id));
            if (srl == null || srl.Status == false)
                return false;

            try
            {
                srl.Status = false;
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Serologion? Get(string id)
        {
            return dbo.Serologions.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Serologion> GetAll()
        {
            return dbo.Serologions.ToList();
        }

        public bool Update(Serologion obj)
        {
            Serologion? srl = dbo.Serologions.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (srl == null)
                return false;
            if(Valid(obj))
            try
            {
                srl.RecoveryDate = obj.RecoveryDate;
                srl.PositiveDate = obj.PositiveDate;
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

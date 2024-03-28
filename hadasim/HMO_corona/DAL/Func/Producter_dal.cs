using DAL.HMO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class Producer_dal:IProducer_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(Producer Producer)
        {
            return ValidationTest.Name(Producer.Name);
        }
        public int Create(Producer obj)
        {
            Producer? prod = dbo.Producers.FirstOrDefault(x => x.Id == obj.Id || (x.Name.Equals(obj.Name)));
            if (prod != null)
                return prod.Id;
            obj.Id = 0;
            if(Valid(obj))
            try
            {
                dbo.Producers.Add(obj);
                dbo.SaveChanges();
                return obj.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }

        public bool Delete(int id)
        {
            Producer? prd = dbo.Producers.FirstOrDefault(x => x.Id == id);
            if (prd == null)
                return false;

            try
            {
                dbo.Producers.Remove(prd);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Producer? Get(int id)
        {
            return dbo.Producers.FirstOrDefault(x => x.Id == id);
        }

        public List<Producer> GetAll()
        {
            return dbo.Producers.ToList();
        }

        public bool Update(Producer obj)
        {
            Producer? prd = dbo.Producers.FirstOrDefault(x => x.Id == obj.Id);
            if (prd == null)
                return false;
            if(Valid(obj))
            try
            {
                prd.Name = obj.Name;
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

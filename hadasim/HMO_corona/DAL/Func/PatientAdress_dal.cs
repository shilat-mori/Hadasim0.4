using DAL.CRUD;
using DAL.HMO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class PatientAdress_dal : IPatientAddress_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(PatientAddress address)
        {
            return ValidationTest.Name(address.City)
                && ValidationTest.Name(address.Street)
                && ValidationTest.Number(address.Number);
        }
        public int Create(PatientAddress obj)
        {
            PatientAddress? pad = dbo.PatientAddresses.FirstOrDefault(x => (x.Id == obj.Id) || ((x.City.Equals(obj.City)) && (x.Street.Equals(obj.Street)) && (x.Number == (obj.Number))));
            if (pad !=null)
                return pad.Id;
            if(Valid(obj))
            try
            {
                dbo.PatientAddresses.Add(obj);
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
            PatientAddress? pa = dbo.PatientAddresses.FirstOrDefault(x => x.Id == id);
            if (pa == null)
                return false;

            try
            {
                dbo.PatientAddresses.Remove(pa);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PatientAddress? Get(int id)
        {
            return dbo.PatientAddresses.FirstOrDefault(x => x.Id == id);
        }

        public List<PatientAddress> GetAll()
        {
            return dbo.PatientAddresses.ToList();
        }

        public bool Update(PatientAddress obj)
        {
            PatientAddress? pa = dbo.PatientAddresses.FirstOrDefault(x => x.Id == obj.Id);
            if (pa == null)
                return false;
            if(Valid(obj))
            try
            {
                pa.City = obj.City;
                pa.Street = obj.Street;
                pa.Number = obj.Number;
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

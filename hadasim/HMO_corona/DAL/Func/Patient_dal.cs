using DAL.CRUD;
using DAL.HMO;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class Patient_dal : IPatient_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(Patient patient)
        {
            bool b = ((dbo.PatientAddresses.FirstOrDefault(x => x.Id == patient.AddressId)!= null) || patient.AddressId == null);
            return ValidationTest.Id(patient.Id)
                && ValidationTest.Name(patient.FirstName)
                && ValidationTest.Name(patient.LastName)
                && (b)
                && ValidationTest.PastDate(patient.BurnDate)
                && ValidationTest.PhoneNumber(patient.Phone)
                ;
        }
        public string? Create(Patient obj)
        {
            Patient? patient = dbo.Patients.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (patient != null)
            {
                if(patient.Status == false)
                {
                    patient.Status = true;
                    dbo.SaveChanges();
                    
                }
                return patient.Id;
            }
            if (Valid(obj))
                try
                {
                    obj.Status = true;
                    dbo.Patients.Add(obj);
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
            Patient? pt = dbo.Patients.FirstOrDefault(x => x.Id.Equals(id));
            if (pt == null || pt.Status==false)
                return false;
            CoronaVaccine? cv = dbo.CoronaVaccines.FirstOrDefault(x=>x.Id.Equals(id));
            Serologion? srl = dbo.Serologions.FirstOrDefault(x => x.Id.Equals(id));
            try
            {
                if (cv != null)
                cv.Status = false;
                if(srl != null)
                srl.Status = false;
                pt.Status = false;
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        public Patient? Get(string id)
        {
            return dbo.Patients.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Patient> GetAll()
        {
            return dbo.Patients.ToList();
        }

        public bool Update(Patient obj)
        {
            Patient? pt = dbo.Patients.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (pt == null)
                return false;
            if(Valid(obj))
            try
            {
                pt.FirstName = obj.FirstName;
                pt.LastName = obj.LastName;
                //pt.Address = obj.Address;
                pt.BurnDate = obj.BurnDate;
                pt.Phone = obj.Phone;
                pt.Tel = obj.Tel;
                pt.AddressId = obj.AddressId;
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

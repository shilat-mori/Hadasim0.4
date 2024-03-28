using DAL.CRUD;
using DAL.HMO;
using DAL.Interfaces;

namespace DAL.Func
{
    public class CoronaVaccine_dal : ICoronaVaccine_dal
    {
        static HmoCoronaContext dbo = new HmoCoronaContext();

        public bool Valid(CoronaVaccine coronaVaccine)
        {
            return ((ValidationTest.Id(coronaVaccine.Id)))
                //&& (dbo.Vaccines.FirstOrDefault(x => x.Id == coronaVaccine.Vac1) != null || coronaVaccine.Vac1 == 0)
                //&& (dbo.Vaccines.FirstOrDefault(x => x.Id == coronaVaccine.Vac2) != null || coronaVaccine.Vac2 == 0)
                //&& (dbo.Vaccines.FirstOrDefault(x => x.Id == coronaVaccine.Vac3) != null || coronaVaccine.Vac3 == 0)
                //&& (dbo.Vaccines.FirstOrDefault(x => x.Id == coronaVaccine.Vac4) != null || coronaVaccine.Vac4 == 0)))
                ;
        }

        public string? Create(CoronaVaccine obj)
        {
            CoronaVaccine? cv = dbo.CoronaVaccines.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (cv != null)
            {
                if (cv.Status != true)
                {
                    cv.Status = true;
                    dbo.SaveChanges();
                    return cv.Id;
                }

                return cv.Id;
            }

            if(Valid(obj)) 
            try
            {
                obj.Status = true;
                dbo.CoronaVaccines.Add(obj);
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
            CoronaVaccine? cv = dbo.CoronaVaccines.FirstOrDefault(x => x.Id.Equals(id));
            if (cv == null || cv.Status==false)
                return false;

            try
            {
                cv.Status = false;
                //dbo.CoronaVaccines.Remove(cv);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CoronaVaccine? Get(string id)
        {
            return dbo.CoronaVaccines.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<CoronaVaccine> GetAll()
        {
            return dbo.CoronaVaccines.ToList();
        }

        public bool Update(CoronaVaccine obj)
        {
            CoronaVaccine? cv = dbo.CoronaVaccines.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (cv == null)
                return false;
            if(Valid(obj))
            try
            {
                cv.Vac1 = obj.Vac1;
                cv.Vac2 = obj.Vac2;
                cv.Vac3 = obj.Vac3;
                cv.Vac4 = obj.Vac4;
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

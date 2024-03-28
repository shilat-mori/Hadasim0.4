using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CRUD
{
    public interface ICRUD<T, TKey> where T : class
    {
        public TKey? Create(T obj);
        public bool Update(T obj);
        public bool Delete(TKey id);
        public T? Get(TKey id);
        public List<T> GetAll();
        public bool Valid(T obj);

    }
}

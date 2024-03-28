using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICRUD_dto<T, TKey> where T : class
    {   
        public TKey? Create(T obj);
        public bool Update(T obj);
        public bool Delete(TKey id);
        public T? Get(TKey id);
        public List<T> GetAll();

    }
}

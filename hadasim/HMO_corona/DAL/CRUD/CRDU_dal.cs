using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CRUD
{
    public class CRDU_dal<T, TKey> : ICRUD<T, TKey> where T: class
    {
        //DB מאפשרים שימוש גנרי ב
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CRDU_dal(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual bool Valid(T obj)
        {
            return true;
        }

        public TKey? Create(T obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
            return default;
        }

        public virtual bool Update(T obj)
        {
            _dbSet.Update(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(TKey id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public T? Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}


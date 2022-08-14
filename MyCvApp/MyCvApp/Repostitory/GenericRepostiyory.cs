using MyCvApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyCvApp.Repostitory
{
    public class GenericRepostiyory<T>  where T : class, new()
    {
        DB_MyCVEntities db = new DB_MyCVEntities();
        public void Add(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
        public void Delete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }
        public void Update(T t)
        {
            db.SaveChanges();
        }
        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }
        public T GetOne(int id)
        {
            return db.Set<T>().Find(id);
        }
      
    }
}
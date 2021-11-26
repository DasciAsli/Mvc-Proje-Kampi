using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c = new Context();
        DbSet<T> _object;


        //Constructor(Yapıcı metod )
        public GenericRepository()
        {
            _object = c.Set<T>(); //_objectin değeri Contexte bağlı olarak gelen T değeri
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter) //Tek bir veri almak için bunu kullanıyoruz
        {
            return _object.SingleOrDefault(filter);//Bir dizi de ya da listede sadece bir değer döndürmek için kullanılan Linq metodu
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter) //Liste halinde verileri getirmek için bunu kullanıyoruz.
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {               
            c.SaveChanges();
        }
    }
}

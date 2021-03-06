using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //T burada generic yapıyı temsil eder.
    //Yani her sınıf için ayrı bir interface belirlemek yerine
    //T nin yerine farklı türlerde veriler getirip ,her sınıf için Interface'i kullanılabiir hale getirerek
    //Kodlarımızı DRY prensibine uygun hale getirmiş olduk
    public interface IRepository<T> 
        
    {
        List<T> List(); //Listeleme
        void Insert(T p); //Ekleme

        void Update(T p); //Güncelleme

        T Get(Expression<Func<T, bool>> filter);
        void Delete(T p); //Silme

        List<T> List(Expression<Func<T, bool>> filter); //Şartlı listeleme yapar

    }
}

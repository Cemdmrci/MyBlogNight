using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //Bu T mutlaka sınıf olacak
    {
        void Insert(T entity); //Dışarıdan T türünde bir entity alacak.
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll(); //Bütün veriyi döndürecek
        T GetById(int id); //Geriye T türünde bir değer döndürür.
    }
}

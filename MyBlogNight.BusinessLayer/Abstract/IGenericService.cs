using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class //Bu T mutlaka sınıf olacak
    {
        void TInsert(T entity); //Dışarıdan T türünde bir entity alacak.
        void TUpdate(T entity);
        void TDelete(int id);
        List<T> TGetAll(); //Bütün veriyi döndürecek
        T TGetById(int id); //Geriye T türünde bir değer döndürür.
    
    }
}

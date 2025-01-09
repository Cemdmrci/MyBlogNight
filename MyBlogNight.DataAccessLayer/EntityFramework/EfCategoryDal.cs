using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal //efcategorydal artık kategori sınıfı için genericrepositoryde yer alan ekle,sil,güncelle,idye göre getir işlemleri için tamamını artık gerçekleştirir.virgül koyarak iki farklı yerden miras aldırmış olduk.  
    {
        public EfCategoryDal(BlogContext context) : base(context)
        {
        }
    }
}

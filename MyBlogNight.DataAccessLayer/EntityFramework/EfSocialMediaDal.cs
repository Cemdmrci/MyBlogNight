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
    public class EfSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal //ekleme,silme,güncelleme gibi işlemleri için sosyal medya sınıfına getirmiş oluyoruz.Böylece tek tek o metotları yazmak zorunda kalmıyoruz.

    {
        public EfSocialMediaDal(BlogContext context) : base(context)
        {
        }
    }
}

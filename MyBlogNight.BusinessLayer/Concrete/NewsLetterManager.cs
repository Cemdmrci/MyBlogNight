using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void TDelete(int id)
        {
            _newsLetterDal.Delete(id);
        }

        public List<NewsLetter> TGetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public NewsLetter TGetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }

        public void TInsert(NewsLetter entity)
        {
            _newsLetterDal.Insert(entity);
        }

        public void TUpdate(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }
    }
}

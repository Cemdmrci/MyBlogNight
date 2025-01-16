using Microsoft.EntityFrameworkCore;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(BlogContext context) : base(context)
        {
        }

        public List<Article> ArticleListWithCategory()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x => x.Category).ToList();//Articletablosunun içine category eklenmiş oldu
            return values;
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x => x.Category).Include(y => y.AppUser).ToList();//Include ile hangi tabloyu hafızaya alacağımı söyler neye ihiyacım varsa onu çağırır.
            return values;
        }

        public Article ArticleListWithCategoryAndAppUserByArticleId(int id)
        {
          var context = new BlogContext();
            var values=context.Articles.Where(x=>x.ArticleId == id).Include(y=>y.Category).Include(z=>z.AppUser).FirstOrDefault();
            return values;
        }

        public void ArticleViewCountIncrease(int id)
        {
            var context = new BlogContext();
            var updatedValue = context.Articles.Find(id);
            updatedValue.ArticleViewCount += 1;
            context.SaveChanges();
        }

        public List<CategoryArticleCountViewModel> CategoryCountArticle()
        {
            var context = new BlogContext();
            return context.Articles.GroupBy(x => new { x.CategoryId, x.Category.CategoryName }).Select(a => new CategoryArticleCountViewModel //GroupBy metodu, Articles tablosundaki verileri CategoryId ve CategoryName (Kategori Kimliği ve Adı) alanlarına göre gruplar.CategoryArticleCountViewModel adında bir modele aktarılır
            {
                CategoryId = a.Key.CategoryId,//a.Key: Grup anahtarını ifade eder (CategoryId ve CategoryName).
                CategoryName = a.Key.CategoryName,//a.Count(): Grup içindeki elemanların sayısını döner. Bu, her kategorideki makale sayısını hesaplar.
                ArticleCount = a.Count()
            }).OrderByDescending(x => x.ArticleCount).ToList();
        }
        public List<Article> GetArticlesByAppUserId(int id)
        {
            var context=new BlogContext();
            var values=context.Articles.Where(x=>x.AppUserId==id).ToList();
            return values;
        }

		public Article GetLastArticle()
		{
			var context = new BlogContext();
            var value = context.Articles.OrderByDescending(x => x.ArticleId).Take(1).FirstOrDefault();
            return value;
		}

        public List<Article> GetLastThreeArticles()
        {
           var context=new BlogContext();
            var values = context.Articles.OrderByDescending(x => x.ArticleId).Take(3).ToList();
            return values;

        }
    }
}

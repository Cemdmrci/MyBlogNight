using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article> //  Article sınıfım için Igenericdalda yer alan metotlarımı kullanabilirim.
    {
        List<Article> ArticleListWithCategory();//Articlelistleri category ile beraber döndüreceğim
        List<Article> ArticleListWithCategoryAndAppUser();
        Article ArticleListWithCategoryAndAppUserByArticleId(int id);
        void ArticleViewCountIncrease(int id);
        List<Article> GetArticlesByAppUserId(int id);
        Article GetLastArticle();
        List<Article> GetLastThreeArticles();
        List<CategoryArticleCountViewModel> CategoryCountArticle();
    }
}

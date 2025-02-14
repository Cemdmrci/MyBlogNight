﻿using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.EntityFramework;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> TArticleListWithCategoryAndAppUser()
        {
            return _articleDal.ArticleListWithCategoryAndAppUser();
        }

        public List<Article> TArticleListWithCategory()
        {
            return _articleDal.ArticleListWithCategory();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public Article TArticleListWithCategoryAndAppUserByArticleId(int id)
        {
            return _articleDal.ArticleListWithCategoryAndAppUserByArticleId(id);
        }

        public void TArticleViewCountIncrease(int id)
        {
            _articleDal.ArticleViewCountIncrease(id);
        }

        public List<Article> TGetArticlesByAppUserId(int id)
        {
            return _articleDal.GetArticlesByAppUserId(id);
        }

		public Article TGetLastArticle()
		{
			return _articleDal.GetLastArticle();
		}

        public List<Article> TGetLastThreeArticles()
        {
            return _articleDal.GetLastThreeArticles();
        }

        public List<CategoryArticleCountViewModel> TCategoryCountArticle()
        {
            return _articleDal.CategoryCountArticle();
        }
    }
}
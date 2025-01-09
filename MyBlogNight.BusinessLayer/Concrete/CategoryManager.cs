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
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;//Entitylerimizle ilişkili olan ınterface Icategorydalda bulunduğundan ıcategorydalı çağırdık.

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void TDelete(int id) //Buradaki Tdelete businessden geliyor.
		{
			_categoryDal.Delete(id); //Buradaki delete dataaccesden geliyor.
		}

		public List<Category> TGetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void TInsert(Category entity)
		{
			if (entity.CategoryName.Length >= 5 && entity.CategoryName.Length <= 50)
			{
				_categoryDal.Insert(entity);
			}
			else
			{
				//hata mesajı
			}
		}

			public void TUpdate(Category entity)
			{
				_categoryDal.Update(entity);
			}
		}
	}

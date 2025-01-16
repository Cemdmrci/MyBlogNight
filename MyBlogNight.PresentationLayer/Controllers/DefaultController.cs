using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using X.PagedList.Mvc.Core;
using X.PagedList.Extensions;

namespace MyBlogNight.PresentationLayer.Controllers
{
	public class DefaultController : Controller
	{
		private readonly INewsLetterService _newsletterService;
		private readonly IArticleService _articleService;

		public DefaultController(INewsLetterService newsletterService, IArticleService articleService)
		{
			_newsletterService = newsletterService;
			_articleService = articleService;
		}

		public IActionResult Index(int page=1)
		{
            const int pageSize = 3;

            var articles = _articleService.TArticleListWithCategoryAndAppUser();

            var pagedArticles = articles.ToPagedList(page, pageSize);

            return View(pagedArticles);
        }

		[HttpPost]
		public IActionResult Subscribe(NewsLetter newsLetter)
		{
            _newsletterService.TInsert(newsLetter);
            TempData["NewsletterMessage"] = "Başarılı bir şekilde abone oldunuz!";
			return RedirectToAction("Index");
		}
	}
}

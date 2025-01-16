using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
	public class _DefaultBannerComponentPartial : ViewComponent
	{
		private readonly IArticleService _articleService;

        public _DefaultBannerComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
		{
			var value = _articleService.TGetLastArticle();
			return View(value);
		}
	}
}

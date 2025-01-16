using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;


namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _DefaultLast3ArticlesComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultLast3ArticlesComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLastThreeArticles();
            return View(values);
        }
    }
}

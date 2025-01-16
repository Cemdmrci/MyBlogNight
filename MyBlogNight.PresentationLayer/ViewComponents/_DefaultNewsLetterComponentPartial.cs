using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _DefaultNewsLetterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var newsletter = new NewsLetter();
            return View(newsletter);
        }
    }
}

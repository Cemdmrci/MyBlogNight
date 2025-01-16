using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _DefaultHeadComponentPartial :ViewComponent
    {
        //private readonly ICategoryService _categoryService;

        //public _DefaultHeadComponentPartial(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

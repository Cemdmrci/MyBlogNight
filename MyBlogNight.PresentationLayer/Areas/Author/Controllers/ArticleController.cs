using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")] //Bir yerin area olduğunu belirtmek için yazılır.
    public class ArticleController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUserId(userValue.Id);//Giriş yapan kullanıcının ıdsine göre bana veri getirecek
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = userValue.Id;
            _articleService.TInsert(article);
            return Redirect("/Author/Article/Index");
        }
        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return Redirect("/Author/Article/Index");
        }
        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var value = _articleService.TGetById(id);
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetById(article.ArticleId);
            article.AppUserId = userValue.Id;
            values.Title = article.Title;
            values.CategoryId = article.CategoryId;
            values.CreatedDate = article.CreatedDate;
            values.CoverImageUrl = article.CoverImageUrl;
            values.MainImageUrl = article.MainImageUrl;
            //article.ArticleViewCount=values.ArticleViewCount;
            values.Detail = article.Detail;
            //article.Comments=values.Comments;
            _articleService.TUpdate(values);
            return Redirect("/Author/Article/Index");
        }
    }
}



using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
	[Area("Author")]
	public class DashboardController : Controller
	{
		private readonly IArticleService _articleService;
		private readonly ICommentService _commentService;
		private readonly ICategoryService _categoryService;
		private readonly UserManager<AppUser> _userManager;

		public DashboardController(IArticleService articleService, ICommentService commentService, ICategoryService categoryService, UserManager<AppUser> userManager)
		{
			_articleService = articleService;
			_commentService = commentService;
			_categoryService = categoryService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var myArticlesCount = _articleService.TGetArticlesByAppUserId(user.Id).Count().ToString();
			ViewBag.ArticlesCount = myArticlesCount;

			var myCommentCount = _commentService.TGetCommentsByAppUserId(user.Id).Count().ToString();
			ViewBag.CommentCount = myCommentCount;

			var categoryOfMyLastArticle = _articleService.TArticleListWithCategoryAndAppUserByArticleId(user.Id);
			ViewBag.CategoryOfArticle = categoryOfMyLastArticle.Category.CategoryName;

			var nameOfMyLastArticle = _articleService.TArticleListWithCategoryAndAppUserByArticleId(user.Id);
			ViewBag.NameOfMyLastArticle = nameOfMyLastArticle.Title;
			return View();
		}
	}
}

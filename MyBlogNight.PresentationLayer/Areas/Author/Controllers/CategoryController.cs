using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using ZendeskApi_v2.Models.Articles;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
	[Area("Author")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly UserManager<AppUser> _userManager;


		public CategoryController(ICategoryService categoryService, UserManager<AppUser> userManager = null)
		{
			_categoryService = categoryService;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var values = _categoryService.TGetAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(Category category)
		{
			var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
			_categoryService.TInsert(category);
			return Redirect("/Author/Category/Index");
		}
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.TDelete(id);
			return Redirect("/Author/Category/Index");
		}
		[HttpGet]
		public IActionResult UpdateCategory(int id) 
		{
			
			var values = _categoryService.TGetById(id);
			return View(values);
			}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(Category category)
		{
			//var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
			//var values = _categoryService.TGetById(category.CategoryId);
			//category.AppUserId = userValue.Id;
			//values.CategoryName = category.CategoryName;
			_categoryService.TUpdate(category);
			return Redirect("/Author/Category/Index");
		}
		}
}

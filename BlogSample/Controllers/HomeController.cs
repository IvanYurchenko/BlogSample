using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using BlogSample.Enums;
using BlogSample.Extentions;
using BlogSample.Services;
using BlogSample.ViewModels;

namespace BlogSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly IStorageService _storageService;

		public HomeController(IStorageService storageService)
		{
			_storageService = storageService;
		}

		[HttpGet]
		[ActionName("Blog")]
		public ActionResult Blog()
		{
			var viewModel = new PostViewModel { GendersList = Gender.Male.ToSelectListItems() };

			return View(viewModel);
		}

		[HttpGet]
		[ActionName("Posts")]
		[ChildActionOnly]
		public ActionResult GetPosts(string searchQuery = null)
		{
			IEnumerable<PostViewModel> posts = _storageService.GetPosts(Session);

			return PartialView("_Posts", posts);
		}

		[HttpPost]
		[ActionName("AddPost")]
		public ActionResult AddPost(PostViewModel postViewModel)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			_storageService.AddPost(Session, postViewModel);

			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}
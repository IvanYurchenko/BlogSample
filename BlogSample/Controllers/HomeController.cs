using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using BlogSample.Hubs;
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
			var viewModel = new PostViewModel { Date = DateTime.UtcNow };

			ViewBag.GendersList = new List<SelectListItem>
			{
				new SelectListItem
				{
					Value = "0",
					Text = "M"
				},
				new SelectListItem
				{
					Value = "1",
					Text = "F"
				}
			};

			return View(viewModel);
		}

		[HttpGet]
		[ActionName("Posts")]
		public ActionResult GetPosts(string searchQuery = null)
		{
			IEnumerable<PostViewModel> posts = _storageService.GetPosts(Session, searchQuery);

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

			BlogHub.RefreshPosts();

			return RedirectToAction("Blog");
		}
	}
}
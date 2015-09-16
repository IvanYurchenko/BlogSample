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
		[HttpGet]
		public ActionResult Blog()
		{
			var viewModel = new PostViewModel { GendersList = Gender.Male.ToSelectListItems() };

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult AddPost(PostViewModel postViewModel)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}
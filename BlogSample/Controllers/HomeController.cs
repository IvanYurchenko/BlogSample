using System.Web.Mvc;
using BlogSample.Enums;
using BlogSample.Extentions;
using BlogSample.ViewModels;

namespace BlogSample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Blog()
		{
			var viewModel = new PostViewModel { GendersList = Gender.Male.ToSelectListItems() };

			return View(viewModel);
		}
	}
}
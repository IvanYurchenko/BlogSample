using System.Collections.Generic;
using System.Web;
using BlogSample.ViewModels;

namespace BlogSample.Services
{
	public interface IStorageService
	{
		void AddPost(HttpSessionStateBase session, PostViewModel postViewModel);

		IEnumerable<PostViewModel> GetPosts(HttpSessionStateBase session);
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogSample.ViewModels;

namespace BlogSample.Services
{
	public class StorageService : IStorageService
	{
		public const string PostsConst = "Posts";
		public const string PostsCountConst = "PostsCount";

		public void AddPost(HttpSessionStateBase session, PostViewModel postViewModel)
		{
			var posts = (IList<PostViewModel>)session[PostsConst];

			var postsCount = (int)session[PostsCountConst];

			postsCount++;

			postViewModel.Id = postsCount;

			posts.Add(postViewModel);

			posts = posts.OrderByDescending(p => p.Date).ToList();

			session[PostsConst] = posts;
			session[PostsCountConst] = postsCount;
		}

		public IEnumerable<PostViewModel> GetPosts(HttpSessionStateBase session, string searchQuery = null)
		{
			List<PostViewModel> posts = ((IList<PostViewModel>)session[PostsConst]).ToList();

			if (searchQuery != null)
			{
				searchQuery = searchQuery.ToLower();

				posts = posts.Where(p => p.Username.ToLower().Contains(searchQuery) 
					|| p.Body.ToLower().Contains(searchQuery))
					.ToList();
			}

			return posts;
		}
	}
}
using System.Collections.Generic;
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

			session[PostsConst] = posts;
			session[PostsCountConst] = postsCount;
		}

		public IEnumerable<PostViewModel> GetPosts(HttpSessionStateBase session)
		{
			var posts = (IEnumerable<PostViewModel>)session[PostsConst];
			return posts;
		}
	}
}
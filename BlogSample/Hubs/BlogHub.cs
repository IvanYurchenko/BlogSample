using Microsoft.AspNet.SignalR;

namespace BlogSample.Hubs
{
	public class BlogHub : Hub
	{
		public static void RefreshPosts()
		{
			IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BlogHub>();
			context.Clients.All.refreshPosts();
		}
	}
}
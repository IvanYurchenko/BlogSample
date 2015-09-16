using Microsoft.AspNet.SignalR;

namespace BlogSample.Hubs
{
	public class BlogHub : Hub
	{
		public const string GroupName = "groupName";

		public static void RefreshPosts()
		{
			IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BlogHub>();
			context.Clients.All.refreshPosts();
		}

		public void Register()
		{
			Groups.Add(Context.ConnectionId, GroupName);
		}
	}
}
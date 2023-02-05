using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ApplicationContext;

namespace CourseManagement.Extensions
{
	public static class MigrationManager
	{
		public static IHost MigrateDatabase(this IHost webHost)
		{
			using (var scope = webHost.Services.CreateScope())
			{
				using var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
				try
				{
					appContext.Database.Migrate();
				}
				catch { }
			}

			return webHost;
		}
	}
}

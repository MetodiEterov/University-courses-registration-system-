using DomainLayer.Configurations;
using DomainLayer.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.ApplicationContext
{
	public class RepositoryContext : IdentityDbContext<User>
	{
		public RepositoryContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Course> Courses { get; set; }

		public DbSet<StudentCourse> StudentCourses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new StudentConfiguration());
			modelBuilder.ApplyConfiguration(new CourseConfiguration());
			modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}
	}
}

using DomainLayer.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.ToTable("Courses");
			builder.HasIndex(u => u.CourseName).IsUnique();
			builder.HasMany(e => e.Students)
			 .WithOne(s => s.Course)
			 .OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
				new Course
				{
					Id = 1,
					CourseName = "Progress and delve deeper into exciting topics including Agile Development, Operating Systems oder Machine Learning."
                },
				new Course
				{
					Id = 2,
					CourseName = "Business & IT"
                },
				new Course
				{
					Id = 3,
					CourseName = "Algorithms and Data Structures in Python (6 EC)"
                },
				new Course
				{
					Id = 4,
					CourseName = "Build a solid foundation within areas such as Management, Computer Architecture, Programming, Backend Development und GUI Design."
                },
				new Course
				{
					Id = 5,
					CourseName = "Mathematics 3: Advanced Linear Algebra and Real Analysis (6 EC)"
                }
			);
		}
	}
}

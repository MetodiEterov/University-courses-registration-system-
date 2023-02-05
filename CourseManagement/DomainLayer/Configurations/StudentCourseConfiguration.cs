using DomainLayer.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
	public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
	{
		public void Configure(EntityTypeBuilder<StudentCourse> builder)
		{
			builder.ToTable("StudentCourses");
			builder.HasKey(s => new { s.StudentId, s.CourseId });

			builder.HasOne(ss => ss.Student)
				.WithMany(s => s.Courses)
				.HasForeignKey(ss => ss.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(ss => ss.Course)
				.WithMany(s => s.Students)
				.HasForeignKey(ss => ss.CourseId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

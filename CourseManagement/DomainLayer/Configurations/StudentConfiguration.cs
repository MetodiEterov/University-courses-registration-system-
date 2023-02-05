using DomainLayer.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.ToTable("Students");
			builder.HasIndex(u => u.StudentEmail).IsUnique();
			builder.HasMany(e => e.Courses)
			 .WithOne(s => s.Student)
			 .OnDelete(DeleteBehavior.Cascade);
		}
	}
}

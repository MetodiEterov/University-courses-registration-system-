namespace DomainLayer.Entities
{
	public class StudentCourse
	{
		public Guid StudentId { get; set; }

		public Student Student { get; set; }

		public int CourseId { get; set; }

		public Course Course { get; set; }
	}
}

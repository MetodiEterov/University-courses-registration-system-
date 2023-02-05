namespace DomainLayer.Entities
{
	public class Course
	{
		public int Id { get; set; }

		public string CourseName { get; set; }

		public bool IsRegistered { get; set; }

		public ICollection<StudentCourse> Students { get; set; }
	}
}

namespace DomainLayer.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentPassword { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
    }
}

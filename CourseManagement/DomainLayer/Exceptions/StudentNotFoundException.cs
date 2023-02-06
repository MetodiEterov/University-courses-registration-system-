namespace DomainLayer.Exceptions
{
	public sealed class StudentNotFoundException : NotFoundException
	{
		public StudentNotFoundException(Guid studentId)
			: base($"The student {studentId} was not found.")
		{
		}
	}
}

namespace DomainLayer.Exceptions
{
	public abstract class BadRequestException : Exception
	{
		protected BadRequestException(string message)
			: base(message)
		{
		}
	}
}

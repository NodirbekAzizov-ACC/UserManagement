using System;
namespace UsersManagement.Helpers.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string Message =
			"404 Not found Exception. There is not any record.") : base(Message)
		{
		}
	}
}


using System;
namespace UsersManagement.Helpers.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string Message = "Provided argument is null")
			: base(Message)
		{
		}
	}
}


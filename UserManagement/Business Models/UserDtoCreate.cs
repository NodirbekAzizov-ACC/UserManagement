using System;
using CsvHelper.Configuration.Attributes;

namespace UsersManagement.BusinessModels
{
	public class UserDtoCreate
	{
		[Index(1)]
		[Name("useridentifier")]
		public int UserIdentifier { get; set; }
		[Index(0)]
		[Name("username")]
		public string UserName { get; set; }
		[Index(5)]
		[Name("email")]
		public string Email { get; set; }
		[Index(2)]
		[Name("age")]
		public int Age { get; set; }
		[Index(4)]
		[Name("phonenumber")]
		public string PhoneNumber { get; set; }
		[Index(3)]
		[Name("city")]
		public string City { get; set; }
	}
}


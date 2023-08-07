using System.ComponentModel.DataAnnotations;

namespace UserManagement.Entity.Models
{
	public class User
	{
		[Required]
		public Guid UserID { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[MaxLength(30)]
		public string? Username { get; set; }
		public int age { get; set; }
		[Phone]
		public string? PhoneNumber { get; set; }
		public string? City { get; set; }
	}
}


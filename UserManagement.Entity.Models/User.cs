using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Entity.Models
{
	[Table("Users")]
	public class User
	{
		[Required]
		public Guid UserId { get; set; }
		[Required]
		[MaxLength(30)]
		public string UserName { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		[MaxLength(50)]
		public string Email { get; set; } = string.Empty;
		public int Age { get; set; }
		[Phone]
		public string? PhoneNumber { get; set; }
		[MaxLength(30)]
		public string? City { get; set; }
	}
}


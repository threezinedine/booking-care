using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("roles")]
	public class Role
	{
		public string Id { get; set; } = string.Empty;
		public string Name_En { get; set; } = string.Empty;
		public string Name_Vi { get; set; } = string.Empty;
	}
}

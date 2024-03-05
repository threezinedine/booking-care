using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("specialties")]
	public class Specialty
	{
		public string Id { get; set; } = string.Empty;
		public string Name_En { get; set; } = string.Empty;
		public string Name_Vi { get; set; } = string.Empty;
		public string Description_Vi { get; set; } = string.Empty;
		public string Description_En { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;

		public List<User> Doctors { get; set; } = new List<User>();
	}
}

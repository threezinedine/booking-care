using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("clinics")]
	public class Clinic
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string Description_Vi { get; set; } = string.Empty;
		public string Description_En { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set; }

		public List<User> Doctors { get; set; } = new List<User>();
	}
}

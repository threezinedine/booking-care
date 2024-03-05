using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("histories")]
	public class History
	{
		public string Id { get; set; } = string.Empty;
		public string DoctorId { get; set; } = string.Empty;
		public string PatientId { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string FileURL { get; set; } = string.Empty;

		public User Doctor { get; set; } = new User();
		public User Patient { get; set; } = new User();
	}
}

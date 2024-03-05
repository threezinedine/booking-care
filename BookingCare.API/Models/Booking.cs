using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("bookings")]
	public class Booking
	{
		public string Id { get; set; } = string.Empty;
		public string StatusId { get; set; } = string.Empty;
		public string DoctorId { get; set; } = string.Empty;
		public string PatientId { get; set; } = string.Empty;
		public DateOnly Date { get; set; }
		public string ScheduleTimeId { get; set; } = string.Empty;

		public Status Status { get; set; } = new Status();
		public User Doctor { get; set; } = new User();
		public User Patient { get; set; } = new User();
		public ScheduleTime ScheduleTime { get; set; } = new ScheduleTime();
	}
}

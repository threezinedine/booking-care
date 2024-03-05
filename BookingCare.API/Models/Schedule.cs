using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("schedules")]
	public class Schedule
	{
		public string Id { get; set; } = string.Empty;
		public int CurrentNumber { get; set; } = 0;
		public int MaxNumber { get; set; } = 0;
		public DateOnly Date { get; set; }
		public string ScheduleTimeId { get; set; } = string.Empty;
		public string DoctorId { get; set; } = string.Empty;

		public ScheduleTime ScheduleTime { get; set; } = new ScheduleTime();
		public User Doctor { get; set; } = new User();
	}
}

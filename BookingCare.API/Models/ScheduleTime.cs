using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("scheduletimes")]
	public class ScheduleTime
	{
		public string Id { get; set; } = string.Empty;
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Shared.ModelDtos
{
	public class ScheduleTimeDto
	{
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
	}
}

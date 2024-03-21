using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
	public class ScheduleTimeSeeder
	{
		public static readonly ScheduleTime EightToNine = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 8, minute: 0, second: 0),
			End = new TimeOnly(hour: 9, minute: 0, second: 0),
		};
		public static readonly ScheduleTime NineToTen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 9, minute: 0, second: 0),
			End = new TimeOnly(hour: 10, minute: 0, second: 0),
		};
		public static readonly ScheduleTime TenToEleven = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 10, minute: 0, second: 0),
			End = new TimeOnly(hour: 11, minute: 0, second: 0),
		};

		public static readonly ScheduleTime ElevenToTwelve = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 11, minute: 0, second: 0),
			End = new TimeOnly(hour: 12, minute: 0, second: 0),
		};

		public static readonly ScheduleTime ThirteenToFourteen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 13, minute: 0, second: 0),
			End = new TimeOnly(hour: 14, minute: 0, second: 0),
		};

		public static readonly ScheduleTime FourteenToFifteen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 14, minute: 0, second: 0),
			End = new TimeOnly(hour: 15, minute: 0, second: 0),
		};

		public static readonly ScheduleTime FifteenToSixteen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 15, minute: 0, second: 0),
			End = new TimeOnly(hour: 16, minute: 0, second: 0),
		};

		public static readonly ScheduleTime SixteenToSeventeen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 16, minute: 0, second: 0),
			End = new TimeOnly(hour: 17, minute: 0, second: 0),
		};

		public static readonly ScheduleTime SeventeenToEighteen = new ScheduleTime
		{
			Id = Guid.NewGuid().ToString(),
			Start = new TimeOnly(hour: 17, minute: 0, second: 0),
			End = new TimeOnly(hour: 18, minute: 0, second: 0),
		};
	}
}

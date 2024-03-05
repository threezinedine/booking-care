using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
	public static class PositionSeeder
	{
		public static readonly Position NonPosition = new Position
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Non Position",
			Name_Vi = "Đéo có",
		};
	}
}

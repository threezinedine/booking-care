using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
	public static class UserSeeder
	{
		public static readonly User DefaultAdmin = new User
		{
			Id = Guid.NewGuid().ToString(),
			Username = "threezinedine",
			RoleId = RoleSeeder.Admin.Id,
			PositionId = PositionSeeder.NonPosition.Id,
			SpecialtyId = SpecialtySeeder.NonSpecialty.Id,
		};
	}
}

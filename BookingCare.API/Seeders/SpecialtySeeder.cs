using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
	public static class SpecialtySeeder
	{
		public static readonly Specialty NonSpecialty = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "No Specialty",
			Name_Vi = "Đéo có chuyên khoa",
			Description_En = "This role is used for non-doctor users",
			Description_Vi = "Chức vụ này dành cho người không phải là bác sĩ",
		};
	}
}

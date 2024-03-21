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
		public static readonly Position DoctorMD = new Position
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Doctor of Medicine",
			Name_Vi = "Trưởng Khoa",
		};
		public static readonly Position DoctorDO = new Position
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Doctor of Osteopathic Medicine",
			Name_Vi = "Bác sĩ y học thực hành",
		};
		public static readonly Position Professor = new Position
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Professor",
			Name_Vi = "Giáo sư",
		};
		public static readonly Position Fellow = new Position
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Fellow",
			Name_Vi = "Thực tập chuyên môn",
		};
	}
}

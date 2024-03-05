using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
    public static class RoleSeeder
    {
        public static readonly Role Patient = new Role
        {
            Id = Guid.NewGuid().ToString(),
            Name_En = "Patient",
            Name_Vi = "Bệnh nhân",
        };

        public static readonly Role Doctor = new Role
        {
			Id = Guid.NewGuid().ToString(),
			Name_En = "Doctor",
            Name_Vi = "Bác sĩ",
        };

        public static readonly Role Admin = new Role
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Admin",
            Name_Vi = "Đấng",
        };
    }
}

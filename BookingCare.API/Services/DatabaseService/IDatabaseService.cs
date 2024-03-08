using BookingCare.API.Models;

namespace BookingCare.API.Services.DatabaseService
{
	public interface IDatabaseService
	{
		public Task Save();
		public Task<List<User>> GetAllUsers();
		public Task<User?> GetUserByUsername(User userInfo);
		public Task AddNewUser(User user);
		public Task ClearUsers();

		public Task<Role?> GetRoleByName(Role roleInfo);
		public Task<Position?> GetPositionByName(Position positionInfo);
		public Task<Specialty?> GetSpecialtyByName(Specialty specialtyInfo);

		public Task<List<Role>> GetAllRoles();
		public Task<List<Position>> GetAllPositions();
	}
}

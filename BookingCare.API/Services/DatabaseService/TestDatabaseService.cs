using BookingCare.API.Models;
using BookingCare.API.Seeders;

namespace BookingCare.API.Services.DatabaseService
{
	public class TestDatabaseService : IDatabaseService
	{
		private List<User> m_Users = new List<User>();

		public Task AddNewUser(User user)
		{
			var clone = user.Clone();
			clone.Role = user.Role;
			clone.Specialty = user.Specialty;
			clone.Position = user.Position;
			m_Users.Add(clone);
			return Task.CompletedTask;
		}

		public Task ClearUsers()
		{
			m_Users.Clear();
			return Task.CompletedTask;
		}

		public Task<List<User>> GetAllUsers()
		{
			return Task.FromResult(m_Users.Select(user => user.Clone()).ToList());
		}

		public Task<User?> GetUserByUsername(User userInfo)
		{
			var user = m_Users.FirstOrDefault(user => user.Username == userInfo.Username);
			return Task.FromResult((user == null) ? null : user);
		}

		public Task Save()
		{
			return Task.CompletedTask;
		}

		public Task<Role?> GetRoleByName(Role role)
		{
			switch (role.Name_En)
			{
				default:
					return Task.FromResult<Role?>(RoleSeeder.Patient);
			}
		}

		public Task<Position?> GetPositionByName(Position positionInfo)
		{
			switch (positionInfo.Name_En)
			{
				default:
					return Task.FromResult<Position?>(PositionSeeder.NonPosition);
			}
		}

		public Task<Specialty?> GetSpecialtyByName(Specialty specialtyInfo)
		{
			switch (specialtyInfo.Name_En)
			{
				default:
					return Task.FromResult<Specialty?>(SpecialtySeeder.NonSpecialty);
			}
		}
	}
}

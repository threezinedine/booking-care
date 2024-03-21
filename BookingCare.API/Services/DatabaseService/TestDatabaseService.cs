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
			return Task.FromResult((user == null) ? null : user.Clone());
		}

		public Task<Role?> GetRoleByName(Role role)
		{
			switch (role.Name_En)
			{
				case "Doctor":
					return Task.FromResult<Role?>(RoleSeeder.Doctor);
				case "Admin":
					return Task.FromResult<Role?>(RoleSeeder.Admin);
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

		public Task<List<Role>> GetAllRoles()
		{
			return Task.FromResult(new List<Role>
			{
				RoleSeeder.Doctor.Clone(),
				RoleSeeder.Patient.Clone(),
				RoleSeeder.Admin.Clone(),
			});
		}

		public Task<List<Position>> GetAllPositions()
		{
			return Task.FromResult(new List<Position>
			{
				PositionSeeder.NonPosition.Clone(),
			});
		}

		public Task<List<Specialty>> GetAllSpecialties()
		{
			return Task.FromResult(new List<Specialty>
			{
				SpecialtySeeder.NonSpecialty.Clone()
			});
		}

		public Task<User?> GetUserById(string id)
		{
			return Task.FromResult(m_Users.FirstOrDefault(user => user.Id == id)?.Clone());
		}

		public Task UpdateUser(User userInfo)
		{
			var user = m_Users.FirstOrDefault(user => user.Username == userInfo.Username);
			user.PhoneNumber = userInfo.PhoneNumber;
			user.Position = userInfo.Position;
			user.Specialty = userInfo.Specialty;
			user.Role = userInfo.Role;
			return Task.CompletedTask;
		}

		public Task DeleteUser(User user)
		{
			var existedUser = m_Users.FirstOrDefault(usr => usr.Id == user.Id);

			if (existedUser != null)
			{
				m_Users.Remove(existedUser);
			}

			return Task.CompletedTask;
		}

		public Task<List<User>> GetUsersByRole(Role fole, int index, int size)
		{
			throw new NotImplementedException();
		}

		public Task<List<ScheduleTime>> GetAllScheduleTimes()
		{
			throw new NotImplementedException();
		}
	}
}

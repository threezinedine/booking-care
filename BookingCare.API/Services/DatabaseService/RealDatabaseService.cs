using BookingCare.API.Contexts;
using BookingCare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.API.Services.DatabaseService
{
	public class RealDatabaseService : IDatabaseService
	{
		private readonly DatabaseContext m_DatabaseContext;
        public RealDatabaseService(DatabaseContext databaseContext)
        {
            m_DatabaseContext = databaseContext; 
        }

		public async Task AddNewUser(User user)
		{
			m_DatabaseContext.Users.Add(user);

			await m_DatabaseContext.SaveChangesAsync();
		}

		public async Task ClearUsers()
		{
			var users = await GetAllUsers();
			m_DatabaseContext.RemoveRange(users);

			await m_DatabaseContext.SaveChangesAsync();
		}

		public async Task DeleteUser(User user)
		{
			m_DatabaseContext.Users.Remove(user);

			await m_DatabaseContext.SaveChangesAsync();
		}

		public Task<List<Position>> GetAllPositions()
		{
			return m_DatabaseContext.Positions.ToListAsync();
		}

		public Task<List<Role>> GetAllRoles()
		{
			return m_DatabaseContext.Roles.ToListAsync();
		}

		public Task<List<ScheduleTime>> GetAllScheduleTimes()
		{
			return m_DatabaseContext.ScheduleTimes
									.OrderBy(scheduleTime => scheduleTime.Start)
									.ToListAsync();
		}

		public Task<List<Specialty>> GetAllSpecialties()
		{
			return m_DatabaseContext.Specialties.ToListAsync();
		}

		public Task<List<User>> GetAllUsers()
		{
			return m_DatabaseContext.Users
					.Include(user => user.Role)
					.Include(user => user.Position)
					.Include(user => user.Specialty)
					.ToListAsync();
		}

		public Task<Position?> GetPositionByName(Position positionInfo)
		{
			return m_DatabaseContext.Positions
					.FirstOrDefaultAsync(pos => pos.Name_En == positionInfo.Name_En);
		}

		public Task<Role?> GetRoleByName(Role roleInfo)
		{
			return m_DatabaseContext.Roles.FirstOrDefaultAsync(role => role.Name_En == roleInfo.Name_En);
		}

		public Task<Specialty?> GetSpecialtyByName(Specialty specialtyInfo)
		{
			return m_DatabaseContext.Specialties
										.FirstOrDefaultAsync(spec => spec.Name_En == specialtyInfo.Name_En);
		}

		public Task<User?> GetUserById(string id)
		{
			return m_DatabaseContext.Users
						.Include(user => user.Position)
						.Include(user => user.Specialty)
						.Include(user => user.Role)
						.FirstOrDefaultAsync(user => user.Id == id);
		}

		public Task<User?> GetUserByUsername(User userInfo)
		{
			return m_DatabaseContext.Users
								.Include(user => user.Role)
								.Include(user => user.Specialty)
								.Include(user => user.Position)
								.FirstOrDefaultAsync(user => user.Username == userInfo.Username);
		}

		public Task<List<User>> GetUsersByRole(Role role, int index, int size)
		{
			if (size == 0)
			{
				return m_DatabaseContext.Users
									.Include(user => user.Role)
									.Include(user => user.Specialty)
									.Include(user => user.Position)
									.Where(user => user.Role == role)
									.ToListAsync();
			}
			else
			{
				return m_DatabaseContext.Users
									.Include(user => user.Role)
									.Include(user => user.Specialty)
									.Include(user => user.Position)
									.Where(user => user.Role == role)
									.Skip(index * size)
									.Take(size)
									.ToListAsync();
			}
		}

		public async Task UpdateUser(User userInfo)
		{
			await m_DatabaseContext.SaveChangesAsync();
		}
	}
}

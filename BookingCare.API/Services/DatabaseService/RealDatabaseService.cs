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

		public Task AddNewUser(User user)
		{
			m_DatabaseContext.Users.Add(user);
			return Task.CompletedTask;
		}

		public async Task ClearUsers()
		{
			var users = await GetAllUsers();
			m_DatabaseContext.RemoveRange(users);
		}

		public Task<List<User>> GetAllUsers()
		{
			return m_DatabaseContext.Users.ToListAsync();
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

		public Task<User?> GetUserByUsername(User userInfo)
		{
			return m_DatabaseContext.Users
								.Include(user => user.Role)
								.Include(user => user.Specialty)
								.Include(user => user.Position)
								.FirstOrDefaultAsync(user => user.Username == userInfo.Username);
		}

		public async Task Save()
		{
			await m_DatabaseContext.SaveChangesAsync();
		}
	}
}

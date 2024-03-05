
namespace BookingCare.API.Services.PasswordHashingService
{
	public class NoHashPasswordHashingService : IPasswordHashingService
	{
		public Task<string?> HashPassword(string originalPassword)
		{
			return Task.FromResult<string?>(originalPassword);
		}

		public Task<bool> IsValidPassword(string password, string hashedPassword)
		{
			return Task.FromResult(password == hashedPassword);
		}
	}
}

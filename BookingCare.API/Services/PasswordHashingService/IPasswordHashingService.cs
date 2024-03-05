namespace BookingCare.API.Services.PasswordHashingService
{
	public interface IPasswordHashingService
	{
		public Task<string?> HashPassword(string originalPassword);
		public Task<bool> IsValidPassword(string password, string hashedPassword);
	}
}

using BookingCare.API.Models;

namespace BookingCare.API.Services.TokenService
{
	public interface ITokenService
	{
		public Task<string> GenerateToken(User user);
	}
}

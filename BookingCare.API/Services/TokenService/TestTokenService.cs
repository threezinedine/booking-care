using BookingCare.API.Models;

namespace BookingCare.API.Services.TokenService
{
	public class TestTokenService : ITokenService
	{
		private string m_Token = string.Empty;
		public Task<string> GenerateToken(User user)
		{
			return Task.FromResult($"{m_Token}-{user.Username}");
		}

		public Task SetToken(string newToken)
		{
			m_Token = newToken;
			return Task.CompletedTask;
		}
	}
}

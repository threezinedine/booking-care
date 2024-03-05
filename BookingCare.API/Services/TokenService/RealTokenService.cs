using BookingCare.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingCare.API.Services.TokenService
{
	public class RealTokenService : ITokenService
	{
		private readonly IConfiguration m_Configuration;
        public RealTokenService(IConfiguration configuration)
        {
			m_Configuration = configuration; 
        }
        public Task<string> GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(m_Configuration.GetSection("Jwt:Key").Value!);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity
				(
					new[]
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id),
						new Claim(ClaimTypes.Name, user.Username),
					}
				),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key), 
					SecurityAlgorithms.HmacSha256Signature
				)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return Task.FromResult(tokenHandler.WriteToken(token));
		}
	}
}

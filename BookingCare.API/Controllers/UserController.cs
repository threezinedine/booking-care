using AutoMapper;
using BookingCare.API.Constants;
using BookingCare.API.Models;
using BookingCare.API.Seeders;
using BookingCare.API.Services.DatabaseService;
using BookingCare.API.Services.PasswordHashingService;
using BookingCare.API.Services.TokenService;
using BookingCare.Shared.ModelDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingCare.API.Controllers
{
    [ApiController]
	[Route("api/user")]
	public class UserController: ControllerBase
	{
		private readonly IMapper m_Mapper;
		private readonly IDatabaseService m_DatabaseService;
		private readonly ITokenService m_TokenService;
		private readonly IPasswordHashingService m_PasswordHashingService;
        public UserController(IMapper mapper,
								ITokenService tokenService, 
								IPasswordHashingService passwordHashingService,
								IDatabaseService databaseService)
        {
			m_Mapper = mapper; 
			m_TokenService = tokenService;
			m_PasswordHashingService = passwordHashingService;
			m_DatabaseService = databaseService;
        }

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> RegisterUser(UserDto userInfo)
		{
			var existedUser = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = userInfo.Username,
			});

			if (existedUser != null) return Conflict(UserConstants.UserExistsErrorMessage);

			var newUser = m_Mapper.Map<User>(userInfo);
			newUser.Id = Guid.NewGuid().ToString();

			var defaultRole = await m_DatabaseService.GetRoleByName(RoleSeeder.Patient)!;
			if (defaultRole != null)
			{
				newUser.Role = defaultRole;
			}

			var defaultSpecialty = await m_DatabaseService.GetSpecialtyByName(SpecialtySeeder.NonSpecialty)!;
			if (defaultSpecialty != null)
			{
				newUser.Specialty = defaultSpecialty;
			}

			var defaultPosition = await m_DatabaseService.GetPositionByName(PositionSeeder.NonPosition)!;
			if (defaultPosition != null)
			{
				newUser.Position = defaultPosition;
			}

			await m_DatabaseService.AddNewUser(newUser);

			try
			{
				await m_DatabaseService.Save();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Created($"api/user", new UserDto());
		}

		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(UserDto userInfo)
		{
			var existedUser = await m_DatabaseService.GetUserByUsername(m_Mapper.Map<User>(userInfo));

			if (existedUser == null) return NotFound(UserConstants.UsernameDoesNotExistErrorMessage);
			if (!(await m_PasswordHashingService.IsValidPassword(userInfo.Password, existedUser.Password)))
			{
				return Unauthorized(UserConstants.PasswordIsIncorrectErrorMessage);
			}

			var token = await m_TokenService.GenerateToken(existedUser);
			return Ok(token);
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public async Task<ActionResult<UserDto>> GetUser()
		{
			var existedUser = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = User.Identity!.Name!
			});
			return Ok(m_Mapper.Map<UserDto>(existedUser));
		}
	}
}

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


			try
			{
				await m_DatabaseService.AddNewUser(newUser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Created($"api/user", new UserDto());
		}

		[HttpPost("register-admin")]
		public async Task<ActionResult<UserDto>> RegisterAdminUser(UserDto userInfo)
		{
			var existedUser = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = userInfo.Username,
			});

			if (existedUser != null) return Conflict(UserConstants.UserExistsErrorMessage);

			var newUser = m_Mapper.Map<User>(userInfo);

			var position = await m_DatabaseService.GetPositionByName(new Position
			{
				Name_En = PositionSeeder.NonPosition.Name_En,
			});

			var specialty = await m_DatabaseService.GetSpecialtyByName(new Specialty
			{
				Name_En = SpecialtySeeder.NonSpecialty.Name_En,
			});

			var role = await m_DatabaseService.GetRoleByName(new Role
			{
				Name_En = RoleSeeder.Admin.Name_En,
			});

			if (position != null && specialty != null && role != null)
			{
				newUser.Position = position;
				newUser.Specialty = specialty;
				newUser.Role = role;
			}
			else
			{
				return BadRequest(UserConstants.InternalErrorMessage);
			}

			try
			{
				await m_DatabaseService.AddNewUser(newUser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Created($"api/user", new UserDto());
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[HttpPut]
		public async Task<ActionResult<UserDto>> UpdateUser(UserDto userInfo)
		{
			var user = await m_DatabaseService.GetUserByUsername(new User { Username = userInfo.Username });

			if (user == null) return BadRequest(UserConstants.UsernameDoesNotExistErrorMessage);

			var position = await m_DatabaseService.GetPositionByName(new Position
			{
				Name_En = userInfo.Position.Name_En,
			});

			if (position != null)
			{
				user.Position = position;
			}

			var specialty = await m_DatabaseService.GetSpecialtyByName(new Specialty
			{
				Name_En = userInfo.Specialty.Name_En,
			});

			if (specialty != null)
			{
				user.Specialty = specialty;
			}

			var role = await m_DatabaseService.GetRoleByName(new Role
			{
				Name_En = userInfo.Role.Name_En,
			});

			if (role != null)
			{
				user.Role = role;
			}

			user.Address = userInfo.Address;
			user.PhoneNumber = userInfo.PhoneNumber;
			user.Email = userInfo.Email;
			user.Gender = userInfo.Gender;
			user.FullName = userInfo.FullName;
			user.ImageUrl = userInfo.ImageUrl;

			try
			{
				await m_DatabaseService.UpdateUser(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			user = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = userInfo.Username,
			});

			return Ok(m_Mapper.Map<UserDto>(user));
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[HttpDelete("{userId}")]
		public async Task<ActionResult> DeleteUser(string userId)
		{
			var user = await m_DatabaseService.GetUserById(userId);

			if (user == null) return NotFound(UserConstants.UsernameDoesNotExistErrorMessage);

			await m_DatabaseService.DeleteUser(user);

			return Ok();
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

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[HttpGet("all")]
		public async Task<ActionResult<List<UserDto>>> GetAllUsers()
		{
			var users = await m_DatabaseService.GetAllUsers();
			return Ok(users.Select(user => m_Mapper.Map<UserDto>(user)));
		}

		[HttpGet("roles")]
		public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
		{
			var roles = await m_DatabaseService.GetAllRoles();
			return Ok(roles.Select(role => m_Mapper.Map<RoleDto>(role)).ToList());
		}

		[HttpGet("positions")]
		public async Task<ActionResult<List<PositionDto>>> GetAllPositions()
		{
			var positions = await m_DatabaseService.GetAllPositions();
			return Ok(positions.Select(pos => m_Mapper.Map<PositionDto>(pos)).ToList());
		}

		[HttpGet("specialties")]
		public async Task<ActionResult<List<SpecialtyDto>>> GetAllSpecialties()
		{
			var specialites = await m_DatabaseService.GetAllSpecialties();
			return Ok(specialites.Select(spec => m_Mapper.Map<SpecialtyDto>(spec)).ToList());
		}

		[HttpGet("doctors")]
		public async Task<ActionResult<List<UserDto>>> GetAllDoctors(int size = 0, int index = 0)
		{
			var role = await m_DatabaseService.GetRoleByName(RoleSeeder.Doctor);

			if (role == null) return BadRequest(UserConstants.InternalErrorMessage);
			var doctors = await m_DatabaseService.GetUsersByRole(role, index, size);

			return Ok(doctors.Select(doctor => m_Mapper.Map<UserDto>(doctor)).ToList());
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<UserDto>> GetUserById(string userId)
		{
			var user = await m_DatabaseService.GetUserById(userId);

			if (user == null) return NotFound(UserConstants.UsernameDoesNotExistErrorMessage);

			return Ok(m_Mapper.Map<UserDto>(user));
		}

		[Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor,Admin")]
		[HttpPut("doctor/description")]
		public async Task<ActionResult<UserDto>> UpdateDoctorDescription(UserDto doctorInfo)
		{
			if (doctorInfo.Username != User.Identity!.Name && ! User.IsInRole("Admin")) return Unauthorized(UserConstants.NoPermissionErrorMessage);
			var doctor = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = doctorInfo.Username,
			});

			if (doctor == null) return BadRequest(UserConstants.UsernameDoesNotExistErrorMessage);

			doctor.Description = doctorInfo.Description;

			try
			{
				await m_DatabaseService.UpdateUser(doctor);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok(m_Mapper.Map<UserDto>(doctor));
		}
	}
}

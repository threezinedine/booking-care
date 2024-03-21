using AutoMapper;
using BookingCare.API.Controllers;
using BookingCare.API.Models;
using BookingCare.API.Profiles;
using BookingCare.API.Services.DatabaseService;
using BookingCare.API.Services.PasswordHashingService;
using BookingCare.API.Services.TokenService;
using BookingCare.Shared.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.API.Test.Fixtures
{
	public class ServerFixture : IDisposable
	{
		private UserController m_UserController;
		private TestTokenService m_TokenService;
		private IPasswordHashingService m_PasswordHashingService;
		private IDatabaseService m_DatabaseService;
		private IMapper m_Mapper;

        public ServerFixture()
        {
			// Automapper configuration
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<AutoMapperProfile>();
			});
			m_Mapper = mapperConfig.CreateMapper();

			// Token Service Configuration
			m_TokenService = new TestTokenService();

			// Password hasing service configuration
			m_PasswordHashingService = new NoHashPasswordHashingService();

			// Database Service configuration
			m_DatabaseService = new TestDatabaseService();

			m_UserController = new UserController(m_Mapper,
													m_TokenService, 
													m_PasswordHashingService,
													m_DatabaseService); 
        }

		public async Task ResetDatabase()
		{
			await m_DatabaseService.ClearUsers();
		}

		public UserController UserController
		{
			get => m_UserController;
		}

		public IDatabaseService DatabaseService
		{
			get => m_DatabaseService;
		}

		public IMapper Mapper
		{
			get => m_Mapper;
		}

		public async Task SetTestToken(string newToken)
		{
			await m_TokenService.SetToken(newToken);
		}

		public async Task LoginAsUser(UserDto userInfo)
		{
			var existedUser = await m_DatabaseService.GetUserByUsername(new User
			{
				Username = userInfo.Username
			});

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, existedUser!.Id),
				new Claim(ClaimTypes.Name, existedUser!.Username)
			}, "mock"));

			m_UserController.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = user }
			};
		}

        public void Dispose()
		{
			m_DatabaseService.ClearUsers();
		}
	}
}

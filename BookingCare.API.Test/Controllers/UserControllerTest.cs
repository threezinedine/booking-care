using BookingCare.API.Test.Fixtures;
using System;
using System.Collections.Generic;
namespace BookingCare.API.Test.Controllers
{
    using FluentAssertions;
    using BookingCare.API.Constants;
    using BookingCare.API.Seeders;
    using BookingCare.API.Test.ResponseParser;
    using BookingCare.Shared.ModelDtos;
    using Microsoft.AspNetCore.Mvc;

    public class UserControllerTest : IClassFixture<ServerFixture>, IDisposable
	{
		private readonly ServerFixture m_ServerFixture;
		private readonly UserDto m_FirstValidUser = new UserDto
		{
			Username = "threezinedine-username",
			Password = "threezinedine-password",
		}; 

        public UserControllerTest(ServerFixture serverFixture)
        {
			m_ServerFixture = serverFixture; 
        }

		[Fact]
        public async void WhenQueryAllUsers_ThenReturnsEmptyList()
		{
			// Act
			var users = await m_ServerFixture.DatabaseService.GetAllUsers();

			// Assert
			users.Count.Should().Be(0);
		}

		[Fact]
		public async void GivenAValidUserIsRegistered_WhenQueryAllUsers_ThenReturnsListWithThatUser()
		{
			// Arrange 
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);

			// Act 
			var users = await m_ServerFixture.DatabaseService.GetAllUsers();

			// Assert 
			users.Count.Should().Be(1);

			var user = users[0];
			user.Id.Should().NotBeEmpty();
			user.Username.Should().Be(m_FirstValidUser.Username);
			user.Password.Should().Be(m_FirstValidUser.Password);
		}

		[Fact]
		public async void GivenAUserIsRegistered_WhenLoginWithValidUsernameAndPassword_ThenReturnsToken()
		{
			// Arrange
			var testToken = "testReturnToken";
			await m_ServerFixture.SetTestToken(testToken);
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);

			// Act
			var result = await m_ServerFixture.UserController.Login(m_FirstValidUser);

			// Assert
			var token = await ResponseParser.GetObjectFromOkResponse<string>(result!);
			token.Should().Be($"{testToken}-{m_FirstValidUser.Username}");
		}

		[Fact]
		public async void GivenAValidUserIsCreated_WhenRegisterTheUserWithTheSameUsername_ThenReturnUserExistsErrorMessage()
		{
			// Arrange
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);

			// Act 
			var result = await m_ServerFixture.UserController.RegisterUser(new UserDto
			{
				Username = m_FirstValidUser.Username,
				Password = $"{m_FirstValidUser.Password}-new"
			});

			// Assert
			var error = await ResponseParser.GetErrorMessageFromConflictResponse(result!);
			error.Should().Be(UserConstants.UserExistsErrorMessage);
		}

		[Fact]
		public async void WhenLoginWithNonExistedUsername_ThenReturnsNonExistedUsernameErrorMessage()
		{
			// Act
			var result = await m_ServerFixture.UserController.Login(m_FirstValidUser);

			// Assert
			var response = await ResponseParser.GetErrorMessageFromNotFoundResponse(result!);
			response.Should().Be(UserConstants.UsernameDoesNotExistErrorMessage);
		}

		[Fact]
		public async void GivenAValidUserIsCreated_WhenLoginWithInvalidPassword_ThenReturnPasswordIsWrongErrorMessage()
		{
			// Arrange 
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);

			// Act 
			var result = await m_ServerFixture.UserController.Login(new UserDto
			{
				Username = m_FirstValidUser.Username,
				Password = $"{m_FirstValidUser.Password}-invalid",
			});

			// Assert 
			var response = await ResponseParser.GetErrorMessageFromUnauthorizedResponse(result!);
			response.Should().Be(UserConstants.PasswordIsIncorrectErrorMessage);
		}

		[Fact]
		public async void GivenAUserIsLoggedIn_WhenQueryTheUserById_ThenReturnsThatUserInformation()
		{
			// Arrange
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);
			await m_ServerFixture.LoginAsUser(m_FirstValidUser);

			// Act 
			var result = await m_ServerFixture.UserController.GetUser();

			// Assert
			var user = await ResponseParser.GetObjectFromOkResponse(result!);
			user.Username.Should().Be(m_FirstValidUser.Username);
			user.Password.Should().Be(string.Empty);
			user.Role_En.Should().Be(RoleSeeder.Patient.Name_En);
			user.Role_Vi.Should().Be(RoleSeeder.Patient.Name_Vi);
			user.Specialty_En.Should().Be(SpecialtySeeder.NonSpecialty.Name_En);
			user.Specialty_Vi.Should().Be(SpecialtySeeder.NonSpecialty.Name_Vi);
			user.Position_En.Should().Be(PositionSeeder.NonPosition.Name_En);
			user.Position_Vi.Should().Be(PositionSeeder.NonPosition.Name_Vi);
		}

		public async void Dispose()
		{
			await m_ServerFixture.ResetDatabase();
		}
	}
}

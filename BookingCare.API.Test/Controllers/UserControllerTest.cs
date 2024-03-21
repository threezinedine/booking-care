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
	using BookingCare.API.Models;

	public class UserControllerTest : IClassFixture<ServerFixture>, IDisposable
	{
		private readonly ServerFixture m_ServerFixture;
		private readonly UserDto m_FirstValidUser = new UserDto
		{
			Username = "threezinedine-username",
			Password = "threezinedine-password",
			PhoneNumber = "1234567890",
			ImageUrl = "test-image-url",
		};
		private readonly UserDto m_SecondValidUser = new UserDto
		{
			Username = "second-username",
			Password = "second-password",
			PhoneNumber = "1234567890",
		};

        public UserControllerTest(ServerFixture serverFixture)
        {
			m_ServerFixture = serverFixture;

			m_FirstValidUser.Position = m_ServerFixture.Mapper.Map<PositionDto>(PositionSeeder.NonPosition);
			m_FirstValidUser.Specialty = m_ServerFixture.Mapper.Map<SpecialtyDto>(SpecialtySeeder.NonSpecialty);
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
		public async void WhenRegisterAnAdminUser_ThatUserIsRegistered()
		{
			// Act 
			var response = await m_ServerFixture.UserController.RegisterAdminUser(m_FirstValidUser);

			// Assert
			var users = await m_ServerFixture.DatabaseService.GetAllUsers();
			var adminUser = users.FirstOrDefault(usr => usr.Username == m_FirstValidUser.Username);

			adminUser.Should().NotBeNull();
			adminUser!.Role.Name_En.Should().Be(RoleSeeder.Admin.Name_En);
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
			user.Role.Name_Vi.Should().Be(RoleSeeder.Patient.Name_Vi);
			user.Role.Name_En.Should().Be(RoleSeeder.Patient.Name_En);
			user.Specialty.Name_Vi.Should().Be(SpecialtySeeder.NonSpecialty.Name_Vi);
			user.Specialty.Name_En.Should().Be(SpecialtySeeder.NonSpecialty.Name_En);
			user.Position.Name_Vi.Should().Be(PositionSeeder.NonPosition.Name_Vi);
			user.Position.Name_En.Should().Be(PositionSeeder.NonPosition.Name_En);
		}

		[Fact]
		public async void WhenQueryAllRoles_ThenReturnsTheRoleList()
		{
			// Act 
			var response = await m_ServerFixture.UserController.GetAllRoles();

			// Assert
			var result = await ResponseParser.GetListObjectFromOkResponse(response!);
			result.Should().NotBeNull();
			result.Count.Should().Be(3);
		}

		[Fact]
		public async void WhenQueryAllPosition_ThenReturnAtLeast1Position()
		{
			// Act 
			var response = await m_ServerFixture.UserController.GetAllPositions();

			// Assert
			var result = await ResponseParser.GetListObjectFromOkResponse(response!);
			result.Should().NotBeNull();
			result.Count.Should().BeGreaterThanOrEqualTo(1);
		}

		[Fact]
		public async void WhenQueryAllSpecialties_ThenReturnAtLeast1Specialty()
		{
			// Act 
			var response = await m_ServerFixture.UserController.GetAllSpecialties();

			// Assert 
			var result = await ResponseParser.GetListObjectFromOkResponse(response!);
			result.Count.Should().BeGreaterThanOrEqualTo(1);
		}

		[Fact]
		public async void GivenAUserIsRegistered_WhenUpdateOtherInformation_TheseValuesAreUpdated()
		{
			// Arrange
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);
			await m_ServerFixture.LoginAsUser(m_FirstValidUser);

			m_FirstValidUser.Role = m_ServerFixture.Mapper.Map<RoleDto>(RoleSeeder.Admin);
			await m_ServerFixture.UserController.UpdateUser(m_FirstValidUser);

			// Act 
			var response = await m_ServerFixture.UserController.GetUser();

			// Assert
			var user = await ResponseParser.GetObjectFromOkResponse(response!);
			user.PhoneNumber.Should().Be(m_FirstValidUser.PhoneNumber);
			user.Position.Name_En.Should().Be(m_FirstValidUser.Position.Name_En);
			user.Specialty.Name_En.Should().Be(m_FirstValidUser.Specialty.Name_En);
			user.Role.Name_En.Should().Be(RoleSeeder.Admin.Name_En);
		}

		[Fact]
		public async void Given2UsersAreRegisteredAndTheFirstOneIsAdmin_WhenTheFirstOneDeleteTheSecondOne_ThenTheSecondOneIsDeleted()
		{
			// Arrange
			await m_ServerFixture.UserController.RegisterUser(m_FirstValidUser);
			await m_ServerFixture.UserController.RegisterUser(m_SecondValidUser);

			var secondUser = await m_ServerFixture.DatabaseService.GetUserByUsername(new User
			{
				Username = m_SecondValidUser.Username,
			});

			await m_ServerFixture.LoginAsUser(m_FirstValidUser);

			// Act 
			var response = await m_ServerFixture.UserController.DeleteUser(secondUser!.Id);

			// Assert
			response.Should().BeOfType<OkResult>();
			var users = await m_ServerFixture.DatabaseService.GetAllUsers();
			users.Count.Should().Be(1);
			users[0].Username.Should().Be(m_FirstValidUser.Username);
		}
		public async void Dispose()
		{
			await m_ServerFixture.ResetDatabase();
		}
	}
}

using BookingCare.Shared.ModelDtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BookingCare.Components.Components
{
	public partial class UserForm
	{
		[Parameter]
		public Func<UserDto, bool, Task>? OnSubmit { get; set; }
		private Form? m_FormRef;
		private string m_ValidatePassword = string.Empty;
		private UserDto User { get; set; } = new UserDto();
		private bool m_EditMode = false;
		private List<RoleDto> m_Roles = new List<RoleDto>();
		private List<PositionDto> m_Positions = new List<PositionDto>();
		private List<SpecialtyDto> m_Specialties = new List<SpecialtyDto>();

		public bool EditMode
		{
			get => m_EditMode;
			set
			{
				if (m_EditMode != value)
				{
					m_EditMode = value;
				}

				if (!m_EditMode)
				{
					m_FormRef?.SetAllErrorStatus(true, new List<string> { "Gender" });
				}
				else
				{
					m_FormRef?.SetAllErrorStatus(false);
				}
			}
		}

		private string Username
		{
			get => User.Username;
			set
			{
				if (User.Username != value)
				{
					User.Username = value;
				}
			}
		}

		private string Password
		{
			get => User.Password;
			set
			{
				if (User.Password != value)
				{
					User.Password = value;
				}
			}
		}

		private string ValidatePassword
		{
			get => m_ValidatePassword;
			set
			{
				if (value != m_ValidatePassword)
				{
					m_ValidatePassword = value;
				}
			}
		}

		private string Email
		{
			get => User.Email;
			set
			{
				if (User.Email != value)
				{
					User.Email = value;
				}
			}
		}

		private List<string> Genders
		{
			get => new List<string> { "Male", "Female", "Other" };
		}

		public string Gender
		{
			get => User.Gender.ToString();
			set
			{
				try
				{
					User.Gender = (Gender)Enum.Parse(typeof(Gender), value);
				}
				catch
				{
					User.Gender = BookingCare.Shared.ModelDtos.Gender.Other;
				}
			}
		}

		public string Address
		{
			get => User.Address;
			set
			{
				if (User.Address != value)
				{
					User.Address = value;
				}
			}
		}

		public string FullName
		{
			get => User.FullName;
			set
			{
				if (User.FullName != value)
				{
					User.FullName = value;
				}
			}
		}

		public string PhoneNumber
		{
			get => User.PhoneNumber;
			set
			{
				if (User.PhoneNumber != value)
				{
					User.PhoneNumber = value;
				}
			}
		}

		public string ImageUrl
		{
			get => User.ImageUrl;
			set
			{
				if (User.ImageUrl != value)
				{
					User.ImageUrl = value;
				}
			}
		}

		public string Role
		{
			get => User.Role.Name_En;
			set
			{
				if (User.Role.Name_En != value)
				{
					User.Role = m_Roles.FirstOrDefault(role => role.Name_En == value)!;
				}
			}
		}

		public string Position
		{
			get => User.Position.Name_En;
			set
			{
				if (User.Position.Name_En != value)
				{
					var position = m_Positions.FirstOrDefault(position => position.Name_En == value);

					if (position != null)
					{
						User.Position = position;
					}
				}
			}
		}

		public string Specialty
		{
			get => User.Specialty.Name_En;
			set
			{
				if (User.Specialty.Name_En != value)
				{
					var specialty = m_Specialties.FirstOrDefault(specialty => specialty.Name_En == value);

					if (specialty != null)
					{
						User.Specialty = specialty;
					}
				}
			}
		}

		public List<string> Specialties
		{
			get => m_Specialties.Select(specialty => specialty.Name_En).ToList();
		}

		public List<string> Roles
		{
			get => m_Roles.Select(role => role.Name_En).ToList();
		}

		public List<string> Positions
		{
			get => m_Positions.Select(position => position.Name_En).ToList();
		}

		private async Task<string?> LoadRoles()
		{
			await m_RequestService.LoadToken();

			var response = await m_RequestService.HttpClient.GetAsync("api/user/roles");

			if (response.IsSuccessStatusCode)
			{
				m_Roles = await response.Content.ReadFromJsonAsync<List<RoleDto>>();
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();	
			}
		}

		private async Task<string?> LoadPositions()
		{
			await m_RequestService.LoadToken();

			var response = await m_RequestService.HttpClient.GetAsync("api/user/positions");

			if (response.IsSuccessStatusCode)
			{
				m_Positions = await response.Content.ReadFromJsonAsync<List<PositionDto>>();
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}

		private async Task<string?> LoadSpecialties()
		{
			await m_RequestService.LoadToken();

			var response = await m_RequestService.HttpClient.GetAsync("api/user/specialties");

			if (response.IsSuccessStatusCode)
			{
				m_Specialties = await response.Content.ReadFromJsonAsync<List<SpecialtyDto>>();
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}

		private string? OnValidateTheValidatePassword(string validatePassword)
		{
			if (validatePassword != User.Password)
			{
				return "The validate password must match the password field";
			}

			return null;
		}

		protected override async Task OnInitializedAsync()
		{
			await LoadRoles();
			await LoadPositions();
			await LoadSpecialties();
		}

		private async Task OnFormSubmit()
		{
			if (OnSubmit != null)
			{
				await OnSubmit.Invoke(User, EditMode);
			}
		}

		public Task Submit()
		{
			return m_FormRef!.Submit();
		}

		public void SetUser(UserDto user)
		{
			User = user;
			ValidatePassword = string.Empty;
		}

		public bool CanSubmit
		{
			get => m_FormRef!.CanSubmit;
		}
	}
}

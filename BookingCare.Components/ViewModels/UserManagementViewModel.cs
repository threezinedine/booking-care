using BookingCare.Components.Components;
using BookingCare.Components.Services.RequestService;
using BookingCare.Components.Services.ToastService;
using BookingCare.Shared.ModelDtos;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace BookingCare.Components.ViewModels
{
	public class UserManagementViewModel : INotifyPropertyChanged
	{
		private UserDto m_User = new UserDto();
		private readonly ToastService m_ToastService;
		private List<UserDto> m_Users = new List<UserDto>();

		private readonly RequestService m_RequesetService;
		private List<string> m_ExcludeProperties = new List<string>
		{ 
			"Id",
			"ImageUrl",
			"Password",
			"Description",
		};
		private Dictionary<string, bool> m_UserDtoProperties = new Dictionary<string, bool>();

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public UserManagementViewModel(RequestService requestService, ToastService toastService)
		{
			m_RequesetService = requestService;
			m_ToastService = toastService;

			var propertiesInfo = typeof(UserDto).GetProperties();

			foreach (var propertyInfo in propertiesInfo)
			{
				if (m_ExcludeProperties.Contains(propertyInfo.Name))
				{
					continue;
				}
				m_UserDtoProperties[propertyInfo.Name] = true;
			}

		}

		public List<UserDto> Users
		{
			get => m_Users;
		}

		public Dictionary<string, bool> UserProperties
		{
			get => m_UserDtoProperties;
		}

		public void SetPropertyDisplayStatus(string name, bool value)
		{
			m_UserDtoProperties[name] = value;
		}

		public string GetPropertyValue(UserDto user, string name)
		{
			var property = user.GetType().GetProperty(name);

			switch (name)
			{
				case "Role":
					return user.Role.Name_En;
				case "Position":
					return user.Position.Name_En;
				case "Specialty":
					return user.Specialty.Name_En;
				default:
					return property != null ? property.GetValue(user)!.ToString()! : string.Empty;
			}
		}

		public string? OnValidatePassword(string password)
		{
			if (password.Length < 8)
			{
				return "Password must have more than 8 characters";
			}

			return null;
		}
		public async Task<string?> LoadUsers()
		{
			await m_RequesetService.LoadToken();

			var response = await m_RequesetService.HttpClient.GetAsync("/api/user/all");

			if (response.IsSuccessStatusCode)
			{
				m_Users = await response.Content.ReadFromJsonAsync<List<UserDto>>();
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}

		private async Task<string?> CreateNewUser(UserDto user)
		{
			await m_RequesetService.LoadToken();

			var response = await m_RequesetService.HttpClient.PostAsJsonAsync("api/user/register", user);

			if (response.IsSuccessStatusCode)
			{
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Create new user",
					Message = "User has been created",
					Type = ToastType.Success,
					Duration = 5000,
				});
				return null;
			}
			else
			{
				string errorMessage = await response.Content.ReadAsStringAsync();
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Create new user",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 5000,
				});
				return errorMessage;
			}
		}

		private async Task<string?> UpdateNewUser(UserDto user)
		{
			await m_RequesetService.LoadToken();

			var response = await m_RequesetService.HttpClient.PutAsJsonAsync("api/user", user);

			if (response.IsSuccessStatusCode)
			{
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Update user",
					Message = "User has been updated",
					Type = ToastType.Success,
					Duration = 5000,
				});
				return null;
			}
			else
			{
				string errorMessage = await response.Content.ReadAsStringAsync();
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Update user",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 5000,
				});
				return errorMessage;
			}
		}

		public async Task OnSubmit(UserDto user, bool edit = false)
		{
			if (!edit)
			{
				await CreateNewUser(user);
			}
			else
			{
				await UpdateNewUser(user);
			}
			await LoadUsers();
		}

		public async Task<string?> DeleteUser(string username)
		{
			await m_RequesetService.LoadToken();
			var user = m_Users.FirstOrDefault(user => user.Username == username);

			if (user == null)
			{
				return "Non existed user";
			}

			var response = await m_RequesetService.HttpClient.DeleteAsync($"api/user/{user.Id}");

			if (response.IsSuccessStatusCode)
			{
				await LoadUsers();
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Delete user",
					Message = "User has been deleted",
					Type = ToastType.Success,
					Duration = 5000,
				});
				return null;
			}
			else
			{
				string errorMessage = await response.Content.ReadAsStringAsync();
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Delete user",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 5000
				});
				return errorMessage;
			}
		}
	}
}

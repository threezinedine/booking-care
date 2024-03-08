using BookingCare.Components.Services.RequestService;
using BookingCare.Shared.ModelDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		private UserDto m_User = new UserDto();
		private readonly RequestService m_RequestService;

        public LoginViewModel(RequestService requestService)
        {
			m_RequestService = requestService; 
        }

        public string Username
		{
			get => m_User.Username;
			set
			{
				m_User.Username = value;
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get => m_User.Password;
			set
			{
				m_User.Password = value; 
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public async Task<string?> Login()
		{
			var response = await m_RequestService.HttpClient.PostAsJsonAsync("api/user/login", m_User);
			
			if (response.IsSuccessStatusCode)
			{
				await m_RequestService.SaveToken(await response.Content.ReadAsStringAsync());
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}

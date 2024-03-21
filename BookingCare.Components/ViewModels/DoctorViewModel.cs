using BookingCare.Components.Services.RequestService;
using BookingCare.Shared.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.ViewModels
{
	public class DoctorViewModel
	{
		private readonly RequestService m_RequestService;
		private UserDto m_Doctor = new UserDto();
		
        public DoctorViewModel(RequestService requestService)
        {
			m_RequestService = requestService; 
        }
		public UserDto Doctor
		{
			get => m_Doctor;
		}
		public string AvatarURL
		{
			get => $"data:image/png;base64, {m_Doctor.ImageUrl}";
		}

		public async Task<string?> UpdateDoctorDescription()
		{
			await m_RequestService.LoadToken();

			var response = await m_RequestService.HttpClient
								.PutAsJsonAsync($"api/user/doctor/description", m_Doctor);

			if (response.IsSuccessStatusCode)
			{
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
        public async Task<string?> LoadDoctorInfo(string doctorId)
		{
			await m_RequestService.LoadToken();

			var response = await m_RequestService.HttpClient 
								.GetAsync($"api/user/{doctorId}");

			if (response.IsSuccessStatusCode)
			{
				m_Doctor = await response.Content.ReadFromJsonAsync<UserDto>();

				if (m_Doctor?.Role.Name_En != "Doctor")
				{
					return "This user is not a doctor";
				}

				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}

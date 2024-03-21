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
	public class DoctorManagementViewModel
	{
		private UserDto m_SelectedDoctor = new UserDto();
		private List<UserDto> m_Doctors = new List<UserDto>();
		private RequestService m_RequsetService;
		private string m_SearchDoctorUsername = string.Empty;
        public DoctorManagementViewModel(RequestService requestService)
        {
			m_RequsetService = requestService; 
        }
		public UserDto SelectedDoctor
		{
			get => m_SelectedDoctor;
		}
        public Task<List<string>> RecommendFunc(string input)
		{
			var result = new List<string>();
			foreach (var doctor in m_Doctors)
			{
				if (doctor.Username.ToLower().Contains(input.ToLower()))
				{
					result.Add(doctor.Username);
				}
			}

			return Task.FromResult(result);
		}

		public string SearchDoctorUsername
		{
			get => m_SearchDoctorUsername;
			set
			{
				if (m_SearchDoctorUsername != value)
				{
					m_SearchDoctorUsername = value;
					var doctor = m_Doctors.FirstOrDefault(d => d.Username == value); 

					if (doctor != null)
					{
						m_SelectedDoctor = doctor;
					}
				}
			}
		}

		public async Task<string?> LoadAllDoctors()
		{
			await m_RequsetService.LoadToken();

			var response = await m_RequsetService.HttpClient.GetAsync("api/user/doctors");

			if (response.IsSuccessStatusCode)
			{
				m_Doctors.Clear();
				m_Doctors = await response.Content.ReadFromJsonAsync<List<UserDto>>();
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}

		public async Task<string?> UpdateDescription()
		{
			await m_RequsetService.LoadToken();

			var response = await m_RequsetService.HttpClient
								.PutAsJsonAsync("api/user/doctor/description", m_SelectedDoctor);

			if (response.IsSuccessStatusCode)
			{
				return null;
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}

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
	public class IndexViewModel
	{
		private readonly RequestService m_RequestService;
        private List<UserDto> m_OutstandingDoctors = new List<UserDto>();

        public IndexViewModel(RequestService requestService)
        {
            m_RequestService = requestService; 
        }

        public List<UserDto> OutstandingDoctors
        {
            get => m_OutstandingDoctors;
        }

        public async Task<string?> LoadOutstandingDoctors()
        {
            await m_RequestService.LoadToken();

            var response = await m_RequestService.HttpClient
                            .GetAsync("api/user/doctors");

            if (response.IsSuccessStatusCode)
            {
				m_OutstandingDoctors = await response.Content.ReadFromJsonAsync<List<UserDto>>();

                return null;	
			}
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}

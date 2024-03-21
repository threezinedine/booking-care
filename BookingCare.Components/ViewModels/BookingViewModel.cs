using BookingCare.Components.Services.RequestService;
using BookingCare.Shared.ModelDtos;
using System.Net.Http.Json;

namespace BookingCare.Components.ViewModels
{
	public class BookingViewModel
	{
		private List<ScheduleTimeDto> m_ScheduleTimes = new List<ScheduleTimeDto>();
		private readonly RequestService m_RequestService;

        public BookingViewModel(RequestService requestService)
        {
            m_RequestService = requestService; 
        }

        public List<ScheduleTimeDto> ScheduleTimes
        {
            get => m_ScheduleTimes;
        }

        public async Task<string?> LoadScheduleTimes()
        {
            await m_RequestService.LoadToken();

            var response = await m_RequestService.HttpClient
                                    .GetAsync("api/booking/scheduletimes");

            if (response.IsSuccessStatusCode)
            {
                m_ScheduleTimes = await response.Content.ReadFromJsonAsync<List<ScheduleTimeDto>>();
                return null;
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}

using Blazored.LocalStorage;
using BookingCare.Components.Services.StorageService;

namespace BookingCare.WebClient.Services.StorageService
{
	public class RealStorageService : IStorageService
    {
        private readonly ILocalStorageService m_LocalStorageService;
        public RealStorageService(ILocalStorageService localStorageService)
        {
            m_LocalStorageService = localStorageService; 
        }

		public async Task Clear()
		{
            await m_LocalStorageService.ClearAsync();
		}

		public async Task ClearValue(string key)
		{
            await m_LocalStorageService.RemoveItemAsync(key);
		}

		public async Task<T?> GetValue<T>(string key)
        {
            return await m_LocalStorageService.GetItemAsync<T>(key);
        }

        public async Task SetValue<T>(string key, T value)
        {
            await m_LocalStorageService.SetItemAsync<T>(key, value);
        }
    }
}

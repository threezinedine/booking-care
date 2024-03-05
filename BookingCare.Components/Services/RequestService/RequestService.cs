using BookingCare.Components.Constants;
using BookingCare.Components.Services.StorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Services.RequestService
{
    public class RequestService
    {
        private readonly HttpClient m_HttpClient;
        private readonly IStorageService m_StorageService;

        public RequestService(HttpClient httpClient, IStorageService storageService)
        {
            m_HttpClient = httpClient; 
            m_StorageService = storageService;
        }

        public HttpClient HttpClient
        {
            get => m_HttpClient;
        }

        public async Task LoadToken()
        {
            var token = await m_StorageService.GetValue<string>(AuthenticationConstants.TokenKey);
            m_HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
        }
    }
}

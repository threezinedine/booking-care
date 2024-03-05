using BookingCare.Shared.ModelDtos;
using BookingCare.Components.Services.RequestService;
using BookingCare.Components.Services.StorageService;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.AuthStateProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly RequestService m_RequestService;
        public CustomAuthStateProvider(RequestService requestService)
        {
            m_RequestService = requestService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity();
            await m_RequestService.LoadToken();

            var response = await m_RequestService.HttpClient.GetAsync("api/user");

            if (!response.IsSuccessStatusCode)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
            }

            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            if (user == null)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
            }

            var userIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username),
            }, "jwt");

            var state = new AuthenticationState(new ClaimsPrincipal(userIdentity));
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}

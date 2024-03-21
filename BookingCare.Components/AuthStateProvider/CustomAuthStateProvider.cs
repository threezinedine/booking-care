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
using Microsoft.AspNetCore.Components;

namespace BookingCare.Components.AuthStateProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly RequestService m_RequestService;
        private readonly NavigationManager m_NavigationManager;
        public CustomAuthStateProvider(RequestService requestService, 
                    NavigationManager navigationManager)
        {
            m_RequestService = requestService;
            m_NavigationManager = navigationManager;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
			var anonymous = new ClaimsIdentity();
            try
            {
				await m_RequestService.LoadToken();

				var response = await m_RequestService.HttpClient.GetAsync("api/user");
				if (!response.IsSuccessStatusCode)
				{
					m_NavigationManager.NavigateTo("login");
					return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
				}

				var user = await response.Content.ReadFromJsonAsync<UserDto>();
				if (user == null)
				{
					m_NavigationManager.NavigateTo("login");
					return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
				}

				var userIdentity = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id),
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Role, user.Role.Name_En),
				}, "jwt");

				var state = new AuthenticationState(new ClaimsPrincipal(userIdentity));
				NotifyAuthenticationStateChanged(Task.FromResult(state));

				return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                m_NavigationManager.NavigateTo("login");
				await m_RequestService.ClearToken();
				return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
            }
        }
    }
}

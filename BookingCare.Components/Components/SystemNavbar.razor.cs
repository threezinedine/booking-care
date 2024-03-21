using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookingCare.Components.Components
{
	public partial class SystemNavbar
	{
		[Parameter]
		public Dictionary<string, List<Tuple<string, string>>> Items { get; set; } 
				= new Dictionary<string, List<Tuple<string, string>>>();
		private AuthenticationState? m_AuthState;


		protected async override Task OnInitializedAsync()
		{
			m_AuthState = await m_AuthenticationStateProvider.GetAuthenticationStateAsync();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Pages
{
	public partial class Logout
	{
		protected override async Task OnInitializedAsync()
		{
			await m_RequestService.ClearToken();
			m_NavigationManager.NavigateTo("/login", true);
		}
	}
}

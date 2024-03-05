using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Navbar
{
	public partial class Support
	{
		[Parameter]
		public string SupportLink { get; set; } = "/support";

		private void NavigateToSupportLink()
		{
			m_NavigationManager.NavigateTo(SupportLink);
		}
	}
}

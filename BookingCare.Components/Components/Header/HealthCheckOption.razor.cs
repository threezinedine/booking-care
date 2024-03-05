using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Header
{
	public partial class HealthCheckOption
	{
		[Parameter]
		public string IconClass { get; set; } = string.Empty;
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		[Parameter]
		public string To { get; set; } = "/";

		private void NavigateTo()
		{
			m_NavigationManager.NavigateTo(To);
		}
	}
}

using BookingCare.Components.Types;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.WrapperSection
{
	public partial class WrapperSection
	{
		[Parameter]
		public string Title { get; set; } = string.Empty;
		[Parameter]
		public string? TitleURL { get; set; }
		[Parameter]
		public ColorType BackgroundColor { get; set; } 
				= ColorType.Grey;
		[Parameter]
		public int Height { get; set; } = 320;
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		private void OnClickTitle()
		{
			if (TitleURL != null && TitleURL != string.Empty)
			{
				m_NavigationManager.NavigateTo(TitleURL);
			}
		}
	}
}

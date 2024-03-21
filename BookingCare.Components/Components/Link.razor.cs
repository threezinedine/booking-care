using Microsoft.AspNetCore.Components;

namespace BookingCare.Components.Components
{
	public partial class Link
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		[Parameter]
		public string URL { get; set; } = string.Empty;
		private void OnClick()
		{
			m_NavigationManager.NavigateTo(URL);
		}

	}
}

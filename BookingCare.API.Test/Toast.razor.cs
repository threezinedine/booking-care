using Microsoft.AspNetCore.Components;

namespace BookingCare.Components.Components
{
	public enum ToastType
	{
		Success,
		Warning,
		Error,
		Info,
		Danger,
	}	
	public struct ToastMessage
	{
		public string Title { get; set; }
		public string Message { get; set; }
		public ToastType Type { get; set; }
		public int Duration { get; set; }
	}

	public partial class Toast: ComponentBase
	{
	}
}

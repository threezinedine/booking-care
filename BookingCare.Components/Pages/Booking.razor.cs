
using BookingCare.Components.Components;

namespace BookingCare.Components.Pages
{
	public partial class Booking
	{
		protected override async Task OnInitializedAsync()
		{
			var errorMessage = await ViewModel.LoadScheduleTimes();

			if (errorMessage != null)
			{
				ToastService.AddMessage(new ToastMessage
				{
					Title = "Error",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 3000,
				});
			}
		}
	}
}

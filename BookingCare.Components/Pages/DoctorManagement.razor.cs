using BookingCare.Components.Components;
using BookingCare.Components.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingCare.Components.Components.Toast;

namespace BookingCare.Components.Pages
{
	public partial class DoctorManagement
	{
		protected override async Task OnInitializedAsync()
		{
			var errorMessage = await ViewModel.LoadAllDoctors();

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

		private async void OnClickUpdate()
		{
			var errorMessage = await ViewModel.UpdateDescription();

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
			else
			{
				ToastService.AddMessage(new ToastMessage
				{
					Title = "Success",
					Message = "Update successfully",
					Type = ToastType.Success,
					Duration = 3000,
				});	
			}
		}
	}
}

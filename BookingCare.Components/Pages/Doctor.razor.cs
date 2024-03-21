using BookingCare.Components.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingCare.Components.Components.Toast;

namespace BookingCare.Components.Pages
{
	public partial class Doctor
	{
		[Parameter]
		public string DoctorId { get; set; } = string.Empty;
		private AuthenticationState m_AuthState;

		protected override async Task OnInitializedAsync()
		{
			m_AuthState = await m_AuthStateProvider.GetAuthenticationStateAsync();
			var errorMessage = await m_ViewModel.LoadDoctorInfo(DoctorId);
			
			if (errorMessage != null)
			{
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Load doctor info failed",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 5000,
				});
			}
		}

		private async void OnUpdateDoctorDescription()
		{
			var errorMessage = await m_ViewModel.UpdateDoctorDescription();
			Console.WriteLine(m_ViewModel.Doctor.Description);
			if (errorMessage != null)
			{
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Update doctor description failed",
					Message = errorMessage,
					Type = ToastType.Error,
					Duration = 3000,
				});
			}
			else
			{
				m_ToastService.AddMessage(new ToastMessage
				{
					Title = "Update doctor description successfully",
					Message = "Your doctor description has been updated",
					Type = ToastType.Success,
					Duration = 3000,
				});
			}
		}
	}
}

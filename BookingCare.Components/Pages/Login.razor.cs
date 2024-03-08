using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Pages
{
	public partial class Login
	{
		private void OnClickForgotPassword()
		{
			m_NavigationManager.NavigateTo("/forgot-password");
		}

		private void OnClickSignUp()
		{
			m_NavigationManager.NavigateTo("/sign-up");
		}

		private async void OnClickLogin()
		{
			var errorMessage = await m_LoginViewModel.Login();

			if (errorMessage != null)
			{
				Console.WriteLine(errorMessage);
			}
			else
			{
				m_NavigationManager.NavigateTo("/", true);
			}
		}
	}
}

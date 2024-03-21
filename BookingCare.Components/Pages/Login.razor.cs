using BookingCare.Components.Components;

namespace BookingCare.Components.Pages
{
	public partial class Login
	{
		private Form? m_FormRef { get; set; }
		private void OnClickForgotPassword()
		{
			m_NavigationManager.NavigateTo("/forgot-password");
		}

		private void OnClickSignUp()
		{
			m_NavigationManager.NavigateTo("/sign-up");
		}

		private async Task OnLogin()
		{
			if (m_FormRef!.CanSubmit)
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

		private async void OnClickLogin()
		{
			await m_FormRef!.Submit();
		}
	}
}

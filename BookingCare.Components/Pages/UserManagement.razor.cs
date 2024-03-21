using BookingCare.Components.Components;
using BookingCare.Shared.ModelDtos;

namespace BookingCare.Components.Pages
{
	public partial class UserManagement
	{
        private Modal? m_Modal;
        private UserForm? m_UserFormRef;
        protected override async Task OnInitializedAsync()
        {
            var errorMessage = await m_ViewModel.LoadUsers();

            if (errorMessage != null)
            {
                Console.WriteLine(errorMessage);
            }
        }

        private void OnClickNewUserButton()
        {
            m_UserFormRef!.SetUser(new UserDto());
            m_UserFormRef!.EditMode = false;
            m_Modal?.OpenModal();
        }

        private void OnClickEditButton(string username)
        {
            m_UserFormRef!.SetUser(m_ViewModel.Users.FirstOrDefault(user => user.Username == username)!
                                    .Clone());
            m_UserFormRef!.EditMode = true;
            m_Modal?.OpenModal();
        }

        private async Task<bool> OnModalSubmit()
        {
            if (m_UserFormRef!.CanSubmit)
            {
				await m_UserFormRef!.Submit();
                StateHasChanged();
                return true;
            }
            return false;
        }
    }
}

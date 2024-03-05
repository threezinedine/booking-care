using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Navbar
{
    public partial class NavItem : ComponentBase
    {
        [Parameter]
        public string To { get; set; } = string.Empty;
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public string SubTitle { get; set; } = string.Empty;    

        private void OnClick()
        {
            m_NavigationManager.NavigateTo(To); 
        }
    }
}

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Navbar
{
    public partial class Navbar
    {
        [Parameter]
        public bool MainPage { get; set; } = true;
    }
}

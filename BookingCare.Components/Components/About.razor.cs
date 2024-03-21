using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components
{
    public partial class About
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
    }
}

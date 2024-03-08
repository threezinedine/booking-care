using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Hoverable
{
	public partial class Hoverable
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}

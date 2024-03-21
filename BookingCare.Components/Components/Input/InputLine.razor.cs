using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Input
{
	public partial class InputLine
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}

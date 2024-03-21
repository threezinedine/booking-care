using Microsoft.AspNetCore.Components;

namespace BookingCare.Components.Components
{
	public partial class Dropdown
	{
		[Parameter]
		public Dictionary<string, List<Tuple<string, string>>> Items { get; set; }
				= new Dictionary<string, List<Tuple<string, string>>>();
	}
}

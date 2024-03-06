using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Slider
{
	public partial class SliderImage
	{
		[Parameter]
		public SliderImageItem Item { get; set; } = new SliderImageItem();
		private string m_MarginStyle = "margin-left: 0";
		private void ClickImage()
		{
			m_NavigationManager.NavigateTo(Item.URL);
		}

		public void SubtractMargin(int margin)
		{
			m_MarginStyle = $"margin-left: -{margin}%";
			StateHasChanged();
		}
	}
}

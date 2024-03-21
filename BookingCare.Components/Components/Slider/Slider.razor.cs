using BookingCare.Components.Types;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Slider
{
	public enum SliderImageType
	{
		Rectangle,
		Circle,
	}
	public class SliderImageItem
	{
		public string Name { get; set; } = string.Empty;
		public string? SubName { get; set; }
		public string URL { get; set; } = string.Empty;
		public SliderImageType ImageType { get; set; } = SliderImageType.Rectangle;
		public string ImageURL { get; set; } = string.Empty;
	}
	public partial class Slider
	{
		[Parameter]
		public string Title { get; set; } = string.Empty;
		[Parameter]
		public string To { get; set; } = string.Empty;
		[Parameter]
		public int MaxDisplayImages { get; set; } = 4;
		[Parameter]
		public List<SliderImageItem> Items { get; set; } = new List<SliderImageItem>();
		[Parameter]
		public ColorType BackgroundColor { get; set; } = ColorType.Grey;
		private SliderImage? m_FirstItem;

		private int m_DisplayIndex = 0;
		private void ClickTitle()
		{
			m_NavigationManager.NavigateTo(To);	
		}

		private void ClickPrevious()
		{
			if (m_DisplayIndex >= MaxDisplayImages)
			{
				m_DisplayIndex -= MaxDisplayImages;
			}
			else
			{
				m_DisplayIndex = 0;
			}

			m_FirstItem!.SubtractMargin(m_DisplayIndex * 25);
		}

		private void ClickNext()
		{
			if (m_DisplayIndex + MaxDisplayImages * 2 <= Items.Count)
			{
				m_DisplayIndex += MaxDisplayImages;
			}
			else if (m_DisplayIndex + MaxDisplayImages < Items.Count)
			{
				m_DisplayIndex = Items.Count - MaxDisplayImages;
			}

			m_FirstItem!.SubtractMargin(m_DisplayIndex * 25);
		}
	}
}

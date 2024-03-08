using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Hoverable
{
	public partial class HoverableItem
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		[Parameter]
		public EventCallback OnHovered { get; set; }
		[Parameter]
		public EventCallback OnUnhovered { get; set; }

		private Task OnHoveredInternal()
		{
			Console.WriteLine("Hover the wrapper");
			return Task.CompletedTask;
		}

		private Task UnHoverInternal()
		{
			Console.WriteLine("Unhover the wrapper");
			return Task.CompletedTask;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			OnHovered = EventCallback.Factory.Create(this, OnHoveredInternal);
			OnUnhovered = EventCallback.Factory.Create(this, OnHoveredInternal);
		}
	}
}

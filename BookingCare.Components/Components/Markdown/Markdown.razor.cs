using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Markdown
{
	public partial class Markdown
	{
		[Parameter]
		public string Content { get; set; } = string.Empty;
		[Parameter]
		public EventCallback<string> ContentChanged { get; set; }

		private string InternalContent
		{
			get => Content;
			set
			{
				if (Content != value)
				{
					Content = value;
					ContentChanged.InvokeAsync(value);
				}
			}
		}
	}
}

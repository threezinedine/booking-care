using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Markdown
{
	public partial class MarkdownPreview
	{
		[Parameter]
		public string Content { get; set; } = string.Empty;

		private string Preview
		{
			get => Markdig.Markdown.ToHtml(Content);
		}
	}
}

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components.Markdown
{
	public partial class MarkdownEditor
	{
		[Parameter]
		public string Id { get; set; } = string.Empty;
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
					ContentChanged.InvokeAsync(Content);
				}
			}
		}

		private void OnContentChanged(ChangeEventArgs e)
		{
			InternalContent = e.Value?.ToString()!;
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				var dotnetHelper = DotNetObjectReference.Create(this);
				await JSRuntime.InvokeVoidAsync("textareaFunctions.addSelectListener", Id, dotnetHelper);
			}
		}

		[JSInvokable]
		public void HandleSelect(string selectedText)
		{
			Console.WriteLine(selectedText);
		}

		public async void InsertHeading1()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "# ", "");
		}

		public async void InsertHeading2()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "## ", "");
		}

		public async void InsertHeading3()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "### ", "");
		}

		public async void InsertBold()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "**", "**");
		}

		public async void InsertItalic()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "*", "*");
		}

		public async void InsertUnderline()
		{
			InternalContent = await JSRuntime
										.InvokeAsync<string>(
											"textareaFunctions.insertText", Id, 
											"<u>", "</u>");
		}

		public async void InsertList()
		{
			InternalContent = await JSRuntime.InvokeAsync<string>("textareaFunctions.insertText", Id, "* ", "");
		}
		public async void InsertImageLink()
		{
			InternalContent = await JSRuntime
								.InvokeAsync<string>(
									"textareaFunctions.insertText", 
									Id, "", "![\"\"]()");
		}
		public async void Undo()
		{
			var result = await JSRuntime.InvokeAsync<string>("textareaFunctions.undo");
			if (result != null)
			{
				InternalContent = result;
			}
		}
	}
}

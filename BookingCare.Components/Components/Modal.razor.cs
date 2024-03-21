using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components
{
	public partial class Modal
	{
		[Parameter]
		public string Title { get; set; } = string.Empty;
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		[Parameter]
		public Func<Task<bool>>? OnSubmit { get; set; }

		private bool m_IsActive = false;

		public void OpenModal()
		{
			m_IsActive = true;	
		}

		private void CloseModal()
		{
			m_IsActive = false;
		}

		private async Task ClickSubmit()
		{
			Console.WriteLine($"Click here");
			bool result = await OnSubmit!.Invoke();
			Console.WriteLine($"Result: {result}");
			if (result)
			{
				CloseModal();
			}
		}
	}
}

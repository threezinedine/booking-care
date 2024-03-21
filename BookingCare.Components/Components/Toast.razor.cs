using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Components
{
	public enum ToastType
	{
		Info,
		Success,
		Warning,
		Error
	}

	public class ToastMessage
	{
		public string Title { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public ToastType Type { get; set; }
		public int Duration { get; set; }
	}
	public partial class Toast
	{
		private List<ToastMessage> m_ToastMessages = new List<ToastMessage>();

		protected override Task OnInitializedAsync()
		{
			m_ToastService.SetToastRef(this);
			return Task.CompletedTask;
		}

		public void AddMessage(ToastMessage message)
		{
			m_ToastMessages.Add(message);

			// setup timer to remove the message
			if (message.Duration > 0)
			{
				Task.Delay(message.Duration).ContinueWith(_ =>
				{
					m_ToastMessages.Remove(message);
					InvokeAsync(StateHasChanged);
				});
			}

			StateHasChanged();
		}

		private void RemoveMessage(ToastMessage message)
		{
			m_ToastMessages.Remove(message);
			StateHasChanged();
		}

		private string GetBackgroundColor(ToastType type)
		{
			switch (type)
			{
				case ToastType.Success:
					return "background-color: var(--success-color)";
				case ToastType.Warning:
					return "background-color: var(--warning-color)";
				case ToastType.Error:
					return "background-color: var(--error-color)";
				default: 
					return "background-color: var(--info-color)";
			}
		}
	}
}

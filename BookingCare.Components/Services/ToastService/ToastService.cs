using BookingCare.Components.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingCare.Components.Components.Toast;

namespace BookingCare.Components.Services.ToastService
{
	public class ToastService
	{
		private Toast? m_ToastRef;
		public void AddMessage(ToastMessage message)
		{
			if (m_ToastRef != null)
			{
				m_ToastRef.AddMessage(message);
			}
		}

		public void SetToastRef(Toast toast)
		{
			m_ToastRef = toast;
		}
	}
}

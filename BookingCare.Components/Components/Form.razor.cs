using Microsoft.AspNetCore.Components;

namespace BookingCare.Components.Components
{
	public partial class Form
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		[Parameter]
		public Func<Task>? OnSubmit { get; set; }

		public bool CanSubmit
		{
			get
			{
				foreach ((string field, bool error) in m_ErrorLists)
				{
					if (error)
					{
						Console.WriteLine($"Cannot submit when the field {field} has error.");
						return false;
					}
				}
				return true;
			}
		}
		private Dictionary<string, bool> m_ErrorLists = new Dictionary<string, bool>();

		public void RegisterInput(string field)
		{
			m_ErrorLists[field] = true;

			Console.WriteLine("Dict: \n");
			foreach ((string key, bool value) in m_ErrorLists)
			{
				Console.WriteLine($"{key}: {value}");
			}
		}

		public void SetErrorStatus (string field, bool error)
		{
			m_ErrorLists[field] = error;
		}

		public void SetAllErrorStatus (bool error, List<string>? excludes = null)
		{
			if (excludes == null)
			{
				foreach (var field in m_ErrorLists.Keys) 
				{
					m_ErrorLists[field] = error;
				}
			}
			else
			{
				foreach (var field in m_ErrorLists.Keys)
				{
					if (!excludes.Contains(field))
					{
						m_ErrorLists[field] = error;
					}
					else
					{
						m_ErrorLists[field] = !error;
					}
				}
			}
		}

		public Task Submit()
		{
			if (CanSubmit)
			{
				return OnSubmit!.Invoke();
			}
			else
			{
				return Task.CompletedTask;
			}
		}
	}
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace BookingCare.Components.Components.Input
{
	public enum InputType
	{
		Text,
		Password,
		Email,
		Image,
	}
	public partial class Input
	{
		[CascadingParameter]
		public Components.Form? FormReference { get; set; }
		[Parameter]
		public InputType Type { get; set; } = InputType.Text;
		[Parameter]
		public bool Required { get; set; } = true;
		[Parameter]
		public Func<string, Task<List<string>>>? RecommendFunc { get; set; }
		[Parameter]
		public string Label { get; set; } = string.Empty;
		[Parameter]
		public string Placeholder { get; set; } = string.Empty;
		[Parameter]
		public string IconClass { get; set; } = string.Empty;
		[Parameter]
		public string Value { get; set; } = string.Empty;
		[Parameter]
		public EventCallback<string> ValueChanged { get; set; }
		[Parameter]
		public List<string> Choices { get; set; } = new List<string>();
		[Parameter]
		public Func<string?, string>? ValidateFunc { get; set; }
		[Parameter]
		public bool Editable { get; set; } = true;
		private bool m_ShowPreview = false;
		private bool m_ShowRecommendation = false;
		private string? m_ErrorMessage { get; set; }
		private ElementReference? m_Element { get; set; }
		private string CurrentValue
		{
			get => Value;
			set
			{
				if (Value != value) 
				{
					Value = value;
					if (IsPropertyRequired())
					{
						m_ErrorMessage = ValidateFunc?.Invoke(value);
						if (FormReference != null)
						{
							if (m_ErrorMessage != null)
							{
								FormReference.SetErrorStatus(Label, true);
							}
							else
							{
								FormReference.SetErrorStatus(Label, false);
							}
						}
					}
					ValueChanged.InvokeAsync(Value);
				}
			}
		}
		private List<string> m_Recommendations = new List<string>();
		private bool IsPropertyRequired()
		{
			return Required && Type != InputType.Image && Choices.Count == 0;
		}
		protected override Task OnInitializedAsync()
		{
			if (FormReference != null)
			{
				if (IsPropertyRequired())
				{
					FormReference.RegisterInput(Label);
				}
			}
			return Task.CompletedTask;
		}
		private async Task UploadFile(InputFileChangeEventArgs e)
		{
			var file = e.File;

			if (file != null)
			{
				var buffer = new byte[file.Size];
				await file.OpenReadStream().ReadAsync(buffer);

				CurrentValue = Convert.ToBase64String(buffer);
			}

		}
		private string DisplayImageURL
		{
			get => $"data:image/png;base64, {Value}";
		}
		private void ShowPreview()
		{
			if (Value != string.Empty)
			{
				m_ShowPreview = true;
			}
		}
		private void HidePreview()
		{
			m_ShowPreview = false;
		}
		private string GetInputType()
		{
			switch (Type)
			{
				case InputType.Text:
					return "text";
				case InputType.Password: 
					return "password";
				case InputType.Email:
					return "email";
				case InputType.Image:
					return "file";	
				default:
					return "text";
			}
		}

		private void OnClickRecommendation(string value)
		{
			CurrentValue = value;
			m_ShowRecommendation = false;
		}

		private async Task OnKeyPress(KeyboardEventArgs e)
		{
			if (e.Key == "Esc")
			{
				m_ShowRecommendation = false;
				return;
			}

			if (m_Element != null && RecommendFunc != null)
			{
				var value = await JSRuntime.InvokeAsync<string>("window.BlazorExtensions.GetValue",
													new object[] { m_Element });
				if (value != string.Empty)
				{
					m_Recommendations = await RecommendFunc.Invoke(value);
					if (m_Recommendations.Count > 0)
					{ 
						m_ShowRecommendation = true;
						StateHasChanged();
					}
				}
				else
				{
					m_ShowRecommendation = false;
				}
			}
		}
	}
}

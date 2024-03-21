using BookingCare.Components.Components.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Pages
{
    public partial class Index
    {
        private List<SliderImageItem> OutstandingDoctors
        {
            get
            {
                List<SliderImageItem> outstandingDoctors = new List<SliderImageItem>();

                foreach (var doctor in m_ViewModel.OutstandingDoctors)
                {
                    outstandingDoctors.Add(new SliderImageItem
                    {
                        Name = $"{doctor.Position.Name_En}: {doctor.Username}",
                        SubName = doctor.Specialty.Name_En,
                        ImageType = SliderImageType.Circle,
                        URL = $"doctor/{doctor.Id}",
                        ImageURL = doctor.ImageUrl,
                    });
                }

                return outstandingDoctors;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await m_ViewModel.LoadOutstandingDoctors();
		}
    }
}

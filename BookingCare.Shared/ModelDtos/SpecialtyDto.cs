using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Shared.ModelDtos
{
	public class SpecialtyDto
	{
		public string Name_En { get; set; } = string.Empty;
		public string Name_Vi { get; set; } = string.Empty;
		public string Description_Vi { get; set; } = string.Empty;
		public string Description_En { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
	}
}

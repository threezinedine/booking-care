using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Shared.ModelDtos
{
	public enum Gender
	{
		Male,
		Female,
		Other,
	}

	public class UserDto
	{
		public string Id { get; set; } = string.Empty;
		public string Username { get; set;} = string.Empty;
		public string Password { get; set;} = string.Empty;
		public string Email { get; set;} = string.Empty;
		public string Address { get; set; } = string.Empty;
		public Gender Gender { get; set; } = Gender.Male;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Role_Vi { get; set; } = string.Empty;
		public string Role_En { get; set; } = string.Empty;
		public string Specialty_En { get; set; } = string.Empty;
		public string Specialty_Vi { get; set; } = string.Empty;
		public string Position_En { get; set; } = string.Empty;
		public string Position_Vi { get; set; } = string.Empty;
	}
}

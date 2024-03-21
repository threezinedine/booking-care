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
		public string FullName { get; set;} = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public RoleDto Role { get; set; } = new RoleDto();
		public SpecialtyDto Specialty { get; set; } = new SpecialtyDto();
		public PositionDto Position { get; set; } = new PositionDto();

		public UserDto Clone()
		{
			return new UserDto
			{
				Id = Id,
				Username = Username,
				Password = Password,
				Email = Email,
				Address = Address,
				Gender = Gender,
				FullName = FullName,
				PhoneNumber = PhoneNumber,
				ImageUrl = ImageUrl,
				Role = Role,
				Position = Position,
				Specialty = Specialty,
			};
		}
	}
}

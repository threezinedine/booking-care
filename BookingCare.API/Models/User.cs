using BookingCare.Shared.ModelDtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCare.API.Models
{
	[Table("users")]
	public class User
	{
		public string Id { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public Gender Gender { get; set; } = Gender.Male;
		public string RoleId { get; set; } = string.Empty;
		public string SpecialtyId { get; set; } = string.Empty;
		public string PositionId { get; set; } = string.Empty;

		public Role Role { get; set; } = new Role();
		public Specialty Specialty { get; set; } = new Specialty();
		public List<Clinic> Clinics { get; set; } = new List<Clinic>();
		public Position Position { get; set; } = new Position();

		public User Clone()
		{
			return new User
			{
				Id = Id,
				Username = Username,
				Password = Password,
				Email = Email,
				PositionId = PositionId,
				Gender = Gender,
				RoleId = RoleId,
				SpecialtyId = SpecialtyId,
			};
		}
	}
}

using BookingCare.API.Models;

namespace BookingCare.API.Seeders
{
	public static class SpecialtySeeder
	{
		public static readonly Specialty NonSpecialty = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "No Specialty",
			Name_Vi = "Đéo có chuyên khoa",
			Description_En = "This role is used for non-doctor users",
			Description_Vi = "Chức vụ này dành cho người không phải là bác sĩ",
		};
		public static readonly Specialty GeneralPractice = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "General Practice",
			Name_Vi = "Y học tổng quát",
			Description_En = "This role is used for general practice doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ y học tổng quát",
		};
		public static readonly Specialty Cardiology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Cardiology",
			Name_Vi = "Tim mạch",
			Description_En = "This role is used for cardiology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ tim mạch",
		};
		public static readonly Specialty Dermatology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Dermatology",
			Name_Vi = "Da liễu",
			Description_En = "This role is used for dermatology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ da liễu",
		};
		public static readonly Specialty Endocrinology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Endocrinology",
			Name_Vi = "Nội tiết",
			Description_En = "This role is used for endocrinology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ nội tiết",
		};

		public static readonly Specialty Gastroenterology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Gastroenterology",
			Name_Vi = "Tiêu hóa",
			Description_En = "This role is used for gastroenterology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ tiêu hóa",
		};

		public static readonly Specialty Hematology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Hematology",
			Name_Vi = "Huyết học",
			Description_En = "This role is used for hematology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ huyết học",
		};

		public static readonly Specialty InfectiousDisease = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Infectious Disease",
			Name_Vi = "Nhiễm trùng",
			Description_En = "This role is used for infectious disease doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ nhiễm trùng",
		};

		public static readonly Specialty Nephrology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Nephrology",
			Name_Vi = "Thận",
			Description_En = "This role is used for nephrology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ thận",
		};

		public static readonly Specialty Neurology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Neurology",
			Name_Vi = "Thần kinh",
			Description_En = "This role is used for neurology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ thần kinh",
		};

		public static readonly Specialty Oncology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Oncology",
			Name_Vi = "Ung thư",
			Description_En = "This role is used for oncology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ ung thư",
		};

		public static readonly Specialty Ophthalmology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Ophthalmology",
			Name_Vi = "Mắt",
			Description_En = "This role is used for ophthalmology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ mắt",
		};

		public static readonly Specialty Orthopedics = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Orthopedics",
			Name_Vi = "Chấn thương chỉnh hình",
			Description_En = "This role is used for orthopedics doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ chấn thương chỉnh hình",
		};

		public static readonly Specialty Otolaryngology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Otolaryngology",
			Name_Vi = "Tai mũi họng",
			Description_En = "This role is used for otolaryngology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ tai mũi họng",
		};

		public static readonly Specialty Pediatrics = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Pediatrics",
			Name_Vi = "Nhi",
			Description_En = "This role is used for pediatrics doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ nhi",
		};

		public static readonly Specialty Psychiatry = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Psychiatry",
			Name_Vi = "Tâm thần học",
			Description_En = "This role is used for psychiatry doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ tâm thần học",
		};

		public static readonly Specialty Pulmonology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Pulmonology",
			Name_Vi = "Hô hấp",
			Description_En = "This role is used for pulmonology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ hô hấp",
		};

		public static readonly Specialty Radiology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Radiology",
			Name_Vi = "X quang",
			Description_En = "This role is used for radiology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ x quang",
		};

		public static readonly Specialty Surgery = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Surgery",
			Name_Vi = "Phẫu thuật",
			Description_En = "This role is used for surgery doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ phẫu thuật",
		};

		public static readonly Specialty Urology = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Urology",
			Name_Vi = "Tiết niệu",
			Description_En = "This role is used for urology doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ tiết niệu",
		};

		public static readonly Specialty VascularSurgery = new Specialty
		{
			Id = Guid.NewGuid().ToString(),
			Name_En = "Vascular Surgery",
			Name_Vi = "Phẫu thuật mạch máu",
			Description_En = "This role is used for vascular surgery doctors",
			Description_Vi = "Chức vụ này dành cho bác sĩ phẫu thuật mạch máu",
		};
	}
}

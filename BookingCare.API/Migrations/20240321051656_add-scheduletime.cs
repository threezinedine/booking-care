using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.API.Migrations
{
    /// <inheritdoc />
    public partial class addscheduletime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "040c651f-3150-4f38-b924-95d7c9f744ac");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "7cf4c911-f306-40d4-9718-80d47366666d");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "a09f70b2-7bfa-46ae-a819-ded8773c614f");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "ae1ffdd6-b9cf-490c-9e7d-1d1de6d520bd");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "e7f122b9-7fbc-41cf-8b5b-1bd341b37ea8");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "878d7e8c-07bd-4527-802f-cd127db0554b");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "95cd5689-e3b7-4ad3-8605-e55e1ff94030");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "fe8cc134-355a-4b3b-90b1-8d9b37dc0d3f");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "0b3a1ca5-3e55-4574-a11f-f23483b696d5");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "23ced782-1c57-4dba-80b6-6efaf8c8f4ec");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "2e5d7b63-e988-42d4-b6bb-98f484df5ffb");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "3b53448a-1f83-4ce2-a116-0d555e4e1faf");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "40a183be-c6bb-40eb-9d67-ef2ef553bc0a");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "490475b2-002c-49ea-9e10-68f643f053f1");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "5645a66f-e1af-4cd8-8946-a6b4b093be52");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "71d40d7d-20b5-422d-a5ec-c13ac0de5bfb");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "8d95efbe-e88c-49eb-9ec9-9d764ec42287");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "9576f8e5-5e3c-4dba-b2b1-ab2b84f0b655");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "9b5f20ce-8b46-4eca-a873-33b4d595b25a");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "9d8499b3-b147-4e97-8dfa-87c08e8a05c7");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "a1e6e016-6c6f-4ffc-b9e6-1fc314ce3cb2");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "a83172a3-6d12-45a0-917a-bb247110fd07");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "b7de1a7f-bfcc-4712-98fc-5ccc637e3646");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "d3b128de-a658-4033-aa4f-e9824388cc53");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "d80a12b9-fcf3-45e1-93fe-393ef76b84ba");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "d85d5256-d308-4370-8aba-be81d9bcc72c");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "e94685f8-d3e4-4ddb-aec8-8dbb5d327038");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "f4cda9d5-f6ab-4548-9fa6-652a1e63d309");

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "28d8800a-f3a7-42e6-a7ef-3cbb4760cc6d", "Non Position", "Đéo có" },
                    { "42578bfd-560a-4158-8b0b-78b722f77343", "Professor", "Giáo sư" },
                    { "b3600b4a-6e32-49f9-9244-479a5fcb7462", "Doctor of Osteopathic Medicine", "Bác sĩ y học thực hành" },
                    { "e636245a-e6db-4972-8ecf-06a0c28164be", "Doctor of Medicine", "Trưởng Khoa" },
                    { "e9510b42-b8c4-494b-9186-bfda1361b313", "Fellow", "Thực tập chuyên môn" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "11891e52-1c84-4f20-bcc3-a81dea8498b9", "Admin", "Đấng" },
                    { "2775d48f-f37e-42db-bb3c-d6aee4a03b99", "Patient", "Bệnh nhân" },
                    { "623c7c85-3746-424d-8035-e2065aab612c", "Doctor", "Bác sĩ" }
                });

            migrationBuilder.InsertData(
                table: "scheduletimes",
                columns: new[] { "Id", "End", "Start" },
                values: new object[,]
                {
                    { "0657de52-ed79-4c63-bfda-4e354950161a", new TimeOnly(12, 0, 0), new TimeOnly(11, 0, 0) },
                    { "54e6c135-75b6-468d-84d9-3d5263986b28", new TimeOnly(11, 0, 0), new TimeOnly(10, 0, 0) },
                    { "5c55b089-7085-4f63-a3b0-ead11acd2a27", new TimeOnly(15, 0, 0), new TimeOnly(14, 0, 0) },
                    { "684de8aa-abf2-4031-ad64-3f5d20d28f77", new TimeOnly(14, 0, 0), new TimeOnly(13, 0, 0) },
                    { "aa9ce14f-5659-41be-b6bd-9a67ed9308ef", new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0) },
                    { "b3199f08-366c-41e2-b7f3-6fbc5ae5b7d0", new TimeOnly(18, 0, 0), new TimeOnly(17, 0, 0) },
                    { "b6b8fa66-eee9-48f8-90d6-03131aea970d", new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { "f4419315-72d2-4f67-b451-30b58cd174d6", new TimeOnly(9, 0, 0), new TimeOnly(8, 0, 0) },
                    { "f72a8046-2d75-4fb5-a156-3bf4c716b405", new TimeOnly(10, 0, 0), new TimeOnly(9, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "specialties",
                columns: new[] { "Id", "Description_En", "Description_Vi", "ImageUrl", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "0dd8bca5-9605-4344-b28b-d2d3a394d077", "This role is used for non-doctor users", "Chức vụ này dành cho người không phải là bác sĩ", "", "No Specialty", "Đéo có chuyên khoa" },
                    { "180f3cf7-2fad-4278-aa9f-88276e3b4634", "This role is used for neurology doctors", "Chức vụ này dành cho bác sĩ thần kinh", "", "Neurology", "Thần kinh" },
                    { "1f63d90f-0115-43a4-8e5f-c2d61c7e2e99", "This role is used for infectious disease doctors", "Chức vụ này dành cho bác sĩ nhiễm trùng", "", "Infectious Disease", "Nhiễm trùng" },
                    { "376e02c2-927c-47ce-bd0d-4bf032a4877a", "This role is used for urology doctors", "Chức vụ này dành cho bác sĩ tiết niệu", "", "Urology", "Tiết niệu" },
                    { "3d3c0d07-9d89-48f8-842a-469a30d14d4b", "This role is used for dermatology doctors", "Chức vụ này dành cho bác sĩ da liễu", "", "Dermatology", "Da liễu" },
                    { "45f45fd0-024e-4f8f-a31c-c9e073949a6d", "This role is used for otolaryngology doctors", "Chức vụ này dành cho bác sĩ tai mũi họng", "", "Otolaryngology", "Tai mũi họng" },
                    { "46873b85-1ba9-4e36-a8b4-643b9d1989a3", "This role is used for oncology doctors", "Chức vụ này dành cho bác sĩ ung thư", "", "Oncology", "Ung thư" },
                    { "53f251ed-5caf-4736-8331-2f00b1ca3053", "This role is used for pulmonology doctors", "Chức vụ này dành cho bác sĩ hô hấp", "", "Pulmonology", "Hô hấp" },
                    { "65d1fe06-b795-4930-87f1-d4d96c7968f0", "This role is used for cardiology doctors", "Chức vụ này dành cho bác sĩ tim mạch", "", "Cardiology", "Tim mạch" },
                    { "6b7d2b32-5cc9-4bdd-a9ba-c0433b5b8462", "This role is used for psychiatry doctors", "Chức vụ này dành cho bác sĩ tâm thần học", "", "Psychiatry", "Tâm thần học" },
                    { "8023326f-4867-45d0-b656-76c32ee6163b", "This role is used for pediatrics doctors", "Chức vụ này dành cho bác sĩ nhi", "", "Pediatrics", "Nhi" },
                    { "a2993f6e-1d86-4cfc-88f8-2845e5ef8003", "This role is used for surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật", "", "Surgery", "Phẫu thuật" },
                    { "ab71059e-49e4-4a58-9df7-cf585cbf3384", "This role is used for gastroenterology doctors", "Chức vụ này dành cho bác sĩ tiêu hóa", "", "Gastroenterology", "Tiêu hóa" },
                    { "b474dc47-22e0-4f63-8ce2-20d51ccff480", "This role is used for endocrinology doctors", "Chức vụ này dành cho bác sĩ nội tiết", "", "Endocrinology", "Nội tiết" },
                    { "c7824f2b-8ece-496e-9457-eff011ddacac", "This role is used for vascular surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật mạch máu", "", "Vascular Surgery", "Phẫu thuật mạch máu" },
                    { "e0c61bc8-61a4-4628-9ec9-6b446326ddff", "This role is used for ophthalmology doctors", "Chức vụ này dành cho bác sĩ mắt", "", "Ophthalmology", "Mắt" },
                    { "ebedfdaa-4f80-4638-a8bb-89efbf1c853b", "This role is used for radiology doctors", "Chức vụ này dành cho bác sĩ x quang", "", "Radiology", "X quang" },
                    { "f5080bb2-6250-48cd-ae4c-4186c8d765ac", "This role is used for general practice doctors", "Chức vụ này dành cho bác sĩ y học tổng quát", "", "General Practice", "Y học tổng quát" },
                    { "f5db58d4-58aa-4c9e-b57f-fde29d30e368", "This role is used for hematology doctors", "Chức vụ này dành cho bác sĩ huyết học", "", "Hematology", "Huyết học" },
                    { "f6085e85-09d2-48d6-b87e-9b6f5745e763", "This role is used for nephrology doctors", "Chức vụ này dành cho bác sĩ thận", "", "Nephrology", "Thận" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "28d8800a-f3a7-42e6-a7ef-3cbb4760cc6d");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "42578bfd-560a-4158-8b0b-78b722f77343");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "b3600b4a-6e32-49f9-9244-479a5fcb7462");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "e636245a-e6db-4972-8ecf-06a0c28164be");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "e9510b42-b8c4-494b-9186-bfda1361b313");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "11891e52-1c84-4f20-bcc3-a81dea8498b9");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "2775d48f-f37e-42db-bb3c-d6aee4a03b99");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "623c7c85-3746-424d-8035-e2065aab612c");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "0657de52-ed79-4c63-bfda-4e354950161a");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "54e6c135-75b6-468d-84d9-3d5263986b28");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "5c55b089-7085-4f63-a3b0-ead11acd2a27");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "684de8aa-abf2-4031-ad64-3f5d20d28f77");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "aa9ce14f-5659-41be-b6bd-9a67ed9308ef");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "b3199f08-366c-41e2-b7f3-6fbc5ae5b7d0");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "b6b8fa66-eee9-48f8-90d6-03131aea970d");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "f4419315-72d2-4f67-b451-30b58cd174d6");

            migrationBuilder.DeleteData(
                table: "scheduletimes",
                keyColumn: "Id",
                keyValue: "f72a8046-2d75-4fb5-a156-3bf4c716b405");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "0dd8bca5-9605-4344-b28b-d2d3a394d077");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "180f3cf7-2fad-4278-aa9f-88276e3b4634");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "1f63d90f-0115-43a4-8e5f-c2d61c7e2e99");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "376e02c2-927c-47ce-bd0d-4bf032a4877a");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "3d3c0d07-9d89-48f8-842a-469a30d14d4b");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "45f45fd0-024e-4f8f-a31c-c9e073949a6d");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "46873b85-1ba9-4e36-a8b4-643b9d1989a3");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "53f251ed-5caf-4736-8331-2f00b1ca3053");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "65d1fe06-b795-4930-87f1-d4d96c7968f0");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "6b7d2b32-5cc9-4bdd-a9ba-c0433b5b8462");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "8023326f-4867-45d0-b656-76c32ee6163b");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "a2993f6e-1d86-4cfc-88f8-2845e5ef8003");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "ab71059e-49e4-4a58-9df7-cf585cbf3384");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "b474dc47-22e0-4f63-8ce2-20d51ccff480");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "c7824f2b-8ece-496e-9457-eff011ddacac");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "e0c61bc8-61a4-4628-9ec9-6b446326ddff");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "ebedfdaa-4f80-4638-a8bb-89efbf1c853b");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "f5080bb2-6250-48cd-ae4c-4186c8d765ac");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "f5db58d4-58aa-4c9e-b57f-fde29d30e368");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "f6085e85-09d2-48d6-b87e-9b6f5745e763");

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "040c651f-3150-4f38-b924-95d7c9f744ac", "Doctor of Medicine", "Trưởng Khoa" },
                    { "7cf4c911-f306-40d4-9718-80d47366666d", "Non Position", "Đéo có" },
                    { "a09f70b2-7bfa-46ae-a819-ded8773c614f", "Doctor of Osteopathic Medicine", "Bác sĩ y học thực hành" },
                    { "ae1ffdd6-b9cf-490c-9e7d-1d1de6d520bd", "Fellow", "Thực tập chuyên môn" },
                    { "e7f122b9-7fbc-41cf-8b5b-1bd341b37ea8", "Professor", "Giáo sư" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "878d7e8c-07bd-4527-802f-cd127db0554b", "Patient", "Bệnh nhân" },
                    { "95cd5689-e3b7-4ad3-8605-e55e1ff94030", "Admin", "Đấng" },
                    { "fe8cc134-355a-4b3b-90b1-8d9b37dc0d3f", "Doctor", "Bác sĩ" }
                });

            migrationBuilder.InsertData(
                table: "specialties",
                columns: new[] { "Id", "Description_En", "Description_Vi", "ImageUrl", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "0b3a1ca5-3e55-4574-a11f-f23483b696d5", "This role is used for non-doctor users", "Chức vụ này dành cho người không phải là bác sĩ", "", "No Specialty", "Đéo có chuyên khoa" },
                    { "23ced782-1c57-4dba-80b6-6efaf8c8f4ec", "This role is used for nephrology doctors", "Chức vụ này dành cho bác sĩ thận", "", "Nephrology", "Thận" },
                    { "2e5d7b63-e988-42d4-b6bb-98f484df5ffb", "This role is used for urology doctors", "Chức vụ này dành cho bác sĩ tiết niệu", "", "Urology", "Tiết niệu" },
                    { "3b53448a-1f83-4ce2-a116-0d555e4e1faf", "This role is used for cardiology doctors", "Chức vụ này dành cho bác sĩ tim mạch", "", "Cardiology", "Tim mạch" },
                    { "40a183be-c6bb-40eb-9d67-ef2ef553bc0a", "This role is used for dermatology doctors", "Chức vụ này dành cho bác sĩ da liễu", "", "Dermatology", "Da liễu" },
                    { "490475b2-002c-49ea-9e10-68f643f053f1", "This role is used for hematology doctors", "Chức vụ này dành cho bác sĩ huyết học", "", "Hematology", "Huyết học" },
                    { "5645a66f-e1af-4cd8-8946-a6b4b093be52", "This role is used for psychiatry doctors", "Chức vụ này dành cho bác sĩ tâm thần học", "", "Psychiatry", "Tâm thần học" },
                    { "71d40d7d-20b5-422d-a5ec-c13ac0de5bfb", "This role is used for neurology doctors", "Chức vụ này dành cho bác sĩ thần kinh", "", "Neurology", "Thần kinh" },
                    { "8d95efbe-e88c-49eb-9ec9-9d764ec42287", "This role is used for otolaryngology doctors", "Chức vụ này dành cho bác sĩ tai mũi họng", "", "Otolaryngology", "Tai mũi họng" },
                    { "9576f8e5-5e3c-4dba-b2b1-ab2b84f0b655", "This role is used for infectious disease doctors", "Chức vụ này dành cho bác sĩ nhiễm trùng", "", "Infectious Disease", "Nhiễm trùng" },
                    { "9b5f20ce-8b46-4eca-a873-33b4d595b25a", "This role is used for ophthalmology doctors", "Chức vụ này dành cho bác sĩ mắt", "", "Ophthalmology", "Mắt" },
                    { "9d8499b3-b147-4e97-8dfa-87c08e8a05c7", "This role is used for gastroenterology doctors", "Chức vụ này dành cho bác sĩ tiêu hóa", "", "Gastroenterology", "Tiêu hóa" },
                    { "a1e6e016-6c6f-4ffc-b9e6-1fc314ce3cb2", "This role is used for pulmonology doctors", "Chức vụ này dành cho bác sĩ hô hấp", "", "Pulmonology", "Hô hấp" },
                    { "a83172a3-6d12-45a0-917a-bb247110fd07", "This role is used for radiology doctors", "Chức vụ này dành cho bác sĩ x quang", "", "Radiology", "X quang" },
                    { "b7de1a7f-bfcc-4712-98fc-5ccc637e3646", "This role is used for surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật", "", "Surgery", "Phẫu thuật" },
                    { "d3b128de-a658-4033-aa4f-e9824388cc53", "This role is used for endocrinology doctors", "Chức vụ này dành cho bác sĩ nội tiết", "", "Endocrinology", "Nội tiết" },
                    { "d80a12b9-fcf3-45e1-93fe-393ef76b84ba", "This role is used for vascular surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật mạch máu", "", "Vascular Surgery", "Phẫu thuật mạch máu" },
                    { "d85d5256-d308-4370-8aba-be81d9bcc72c", "This role is used for pediatrics doctors", "Chức vụ này dành cho bác sĩ nhi", "", "Pediatrics", "Nhi" },
                    { "e94685f8-d3e4-4ddb-aec8-8dbb5d327038", "This role is used for oncology doctors", "Chức vụ này dành cho bác sĩ ung thư", "", "Oncology", "Ung thư" },
                    { "f4cda9d5-f6ab-4548-9fa6-652a1e63d309", "This role is used for general practice doctors", "Chức vụ này dành cho bác sĩ y học tổng quát", "", "General Practice", "Y học tổng quát" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.API.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptionforuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "0a0c8a4a-db06-44b4-a568-f9e3f09dac48");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "6afc3f27-6d4e-4050-a78d-c648393bcc1d");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "b5f615df-5006-4ab3-9b30-9fe5b3e87c1c");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "bd62ddca-2e06-4f95-b191-2084cceca3ac");

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "Id",
                keyValue: "ec041a65-1601-4a8b-8141-85769c9f4b7a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "0c3d473b-100d-43c0-9bf4-14bdd2810a55");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "23dc80bc-71eb-47f2-96b7-86525058c735");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "6faa8346-b48e-4c72-b639-7d7b56ea9c36");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "06b5f3fc-2d2d-4af4-bc02-a2f9bcaccabe");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "1035eb90-df7c-437e-8914-e28f58dd0be4");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "14f8cfc0-18a9-4839-9617-3a74b7664ce1");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "204c3b8b-590c-4aac-91f6-03638683c76c");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "317205c0-4a50-47e2-9d38-dd24197f6b91");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "33d7ee8c-3c88-419e-874a-fe64e321a5d2");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "426c853f-c038-4507-8b8c-764ed57dee0d");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "4748b4b6-cb22-4b3f-a7d5-3dc0fdac3204");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "4cb4e0e7-5142-4ddd-9443-1e93e9e455b4");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "55a6de2f-ee00-4346-abbc-f0a9c709fe9b");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "591dc94f-e850-4e7e-86fa-21409fdd5914");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "66005a74-404d-4ac8-a73e-343d392f0af8");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "70ba2fb8-5280-4b55-b8cc-805b06b669d5");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "720dc86b-86ee-4048-9540-74fd3eb42ca9");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "830618e4-7edf-439f-b523-7595ff94ff1e");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "86a47f17-8d18-4d44-8211-78fe1c47ea52");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "922a6f25-2fdb-4236-96f8-5b42e788385b");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "94b3d632-0fc4-4cf0-8c57-cf634ee1bac9");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "9f982568-56ba-4c1f-a8d9-389a4d839edf");

            migrationBuilder.DeleteData(
                table: "specialties",
                keyColumn: "Id",
                keyValue: "b275c5bd-169d-40f6-a9e8-1358973d9836");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "users");

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "0a0c8a4a-db06-44b4-a568-f9e3f09dac48", "Professor", "Giáo sư" },
                    { "6afc3f27-6d4e-4050-a78d-c648393bcc1d", "Non Position", "Đéo có" },
                    { "b5f615df-5006-4ab3-9b30-9fe5b3e87c1c", "Doctor of Medicine", "Trưởng Khoa" },
                    { "bd62ddca-2e06-4f95-b191-2084cceca3ac", "Doctor of Osteopathic Medicine", "Bác sĩ y học thực hành" },
                    { "ec041a65-1601-4a8b-8141-85769c9f4b7a", "Fellow", "Thực tập chuyên môn" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "0c3d473b-100d-43c0-9bf4-14bdd2810a55", "Patient", "Bệnh nhân" },
                    { "23dc80bc-71eb-47f2-96b7-86525058c735", "Doctor", "Bác sĩ" },
                    { "6faa8346-b48e-4c72-b639-7d7b56ea9c36", "Admin", "Đấng" }
                });

            migrationBuilder.InsertData(
                table: "specialties",
                columns: new[] { "Id", "Description_En", "Description_Vi", "ImageUrl", "Name_En", "Name_Vi" },
                values: new object[,]
                {
                    { "06b5f3fc-2d2d-4af4-bc02-a2f9bcaccabe", "This role is used for pulmonology doctors", "Chức vụ này dành cho bác sĩ hô hấp", "", "Pulmonology", "Hô hấp" },
                    { "1035eb90-df7c-437e-8914-e28f58dd0be4", "This role is used for radiology doctors", "Chức vụ này dành cho bác sĩ x quang", "", "Radiology", "X quang" },
                    { "14f8cfc0-18a9-4839-9617-3a74b7664ce1", "This role is used for hematology doctors", "Chức vụ này dành cho bác sĩ huyết học", "", "Hematology", "Huyết học" },
                    { "204c3b8b-590c-4aac-91f6-03638683c76c", "This role is used for gastroenterology doctors", "Chức vụ này dành cho bác sĩ tiêu hóa", "", "Gastroenterology", "Tiêu hóa" },
                    { "317205c0-4a50-47e2-9d38-dd24197f6b91", "This role is used for endocrinology doctors", "Chức vụ này dành cho bác sĩ nội tiết", "", "Endocrinology", "Nội tiết" },
                    { "33d7ee8c-3c88-419e-874a-fe64e321a5d2", "This role is used for surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật", "", "Surgery", "Phẫu thuật" },
                    { "426c853f-c038-4507-8b8c-764ed57dee0d", "This role is used for ophthalmology doctors", "Chức vụ này dành cho bác sĩ mắt", "", "Ophthalmology", "Mắt" },
                    { "4748b4b6-cb22-4b3f-a7d5-3dc0fdac3204", "This role is used for urology doctors", "Chức vụ này dành cho bác sĩ tiết niệu", "", "Urology", "Tiết niệu" },
                    { "4cb4e0e7-5142-4ddd-9443-1e93e9e455b4", "This role is used for dermatology doctors", "Chức vụ này dành cho bác sĩ da liễu", "", "Dermatology", "Da liễu" },
                    { "55a6de2f-ee00-4346-abbc-f0a9c709fe9b", "This role is used for vascular surgery doctors", "Chức vụ này dành cho bác sĩ phẫu thuật mạch máu", "", "Vascular Surgery", "Phẫu thuật mạch máu" },
                    { "591dc94f-e850-4e7e-86fa-21409fdd5914", "This role is used for nephrology doctors", "Chức vụ này dành cho bác sĩ thận", "", "Nephrology", "Thận" },
                    { "66005a74-404d-4ac8-a73e-343d392f0af8", "This role is used for general practice doctors", "Chức vụ này dành cho bác sĩ y học tổng quát", "", "General Practice", "Y học tổng quát" },
                    { "70ba2fb8-5280-4b55-b8cc-805b06b669d5", "This role is used for psychiatry doctors", "Chức vụ này dành cho bác sĩ tâm thần học", "", "Psychiatry", "Tâm thần học" },
                    { "720dc86b-86ee-4048-9540-74fd3eb42ca9", "This role is used for oncology doctors", "Chức vụ này dành cho bác sĩ ung thư", "", "Oncology", "Ung thư" },
                    { "830618e4-7edf-439f-b523-7595ff94ff1e", "This role is used for infectious disease doctors", "Chức vụ này dành cho bác sĩ nhiễm trùng", "", "Infectious Disease", "Nhiễm trùng" },
                    { "86a47f17-8d18-4d44-8211-78fe1c47ea52", "This role is used for pediatrics doctors", "Chức vụ này dành cho bác sĩ nhi", "", "Pediatrics", "Nhi" },
                    { "922a6f25-2fdb-4236-96f8-5b42e788385b", "This role is used for neurology doctors", "Chức vụ này dành cho bác sĩ thần kinh", "", "Neurology", "Thần kinh" },
                    { "94b3d632-0fc4-4cf0-8c57-cf634ee1bac9", "This role is used for otolaryngology doctors", "Chức vụ này dành cho bác sĩ tai mũi họng", "", "Otolaryngology", "Tai mũi họng" },
                    { "9f982568-56ba-4c1f-a8d9-389a4d839edf", "This role is used for cardiology doctors", "Chức vụ này dành cho bác sĩ tim mạch", "", "Cardiology", "Tim mạch" },
                    { "b275c5bd-169d-40f6-a9e8-1358973d9836", "This role is used for non-doctor users", "Chức vụ này dành cho người không phải là bác sĩ", "", "No Specialty", "Đéo có chuyên khoa" }
                });
        }
    }
}

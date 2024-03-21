using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingCare.API.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Description_Vi = table.Column<string>(type: "TEXT", nullable: false),
                    Description_En = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name_En = table.Column<string>(type: "TEXT", nullable: false),
                    Name_Vi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name_En = table.Column<string>(type: "TEXT", nullable: false),
                    Name_Vi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scheduletimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Start = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    End = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduletimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name_En = table.Column<string>(type: "TEXT", nullable: false),
                    Name_Vi = table.Column<string>(type: "TEXT", nullable: false),
                    Description_Vi = table.Column<string>(type: "TEXT", nullable: false),
                    Description_En = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name_En = table.Column<string>(type: "TEXT", nullable: false),
                    Name_Vi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    SpecialtyId = table.Column<string>(type: "TEXT", nullable: false),
                    PositionId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    StatusId = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorId = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ScheduleTimeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_scheduletimes_ScheduleTimeId",
                        column: x => x.ScheduleTimeId,
                        principalTable: "scheduletimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicUser",
                columns: table => new
                {
                    ClinicsId = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicUser", x => new { x.ClinicsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ClinicUser_clinics_ClinicsId",
                        column: x => x.ClinicsId,
                        principalTable: "clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicUser_users_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "histories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorId = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FileURL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_histories_users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_histories_users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ScheduleTimeId = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schedules_scheduletimes_ScheduleTimeId",
                        column: x => x.ScheduleTimeId,
                        principalTable: "scheduletimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_bookings_DoctorId",
                table: "bookings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_PatientId",
                table: "bookings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ScheduleTimeId",
                table: "bookings",
                column: "ScheduleTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_StatusId",
                table: "bookings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicUser_DoctorsId",
                table: "ClinicUser",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_histories_DoctorId",
                table: "histories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_histories_PatientId",
                table: "histories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_DoctorId",
                table: "schedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_ScheduleTimeId",
                table: "schedules",
                column: "ScheduleTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_users_PositionId",
                table: "users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_users_SpecialtyId",
                table: "users",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "ClinicUser");

            migrationBuilder.DropTable(
                name: "histories");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "clinics");

            migrationBuilder.DropTable(
                name: "scheduletimes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "specialties");
        }
    }
}

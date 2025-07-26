using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Picture = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    AppointmentTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false, defaultValue: new TimeSpan(0, 9, 0, 0, 0)),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false, defaultValue: new TimeSpan(0, 17, 0, 0, 0)),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8520), true, false, null, "Kardiyoloji" },
                    { 2, new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8530), true, false, null, "Ortopedi" },
                    { 3, new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8530), true, false, null, "Nöroloji" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "İstanbul, Türkiye", new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1600), new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", "Ahmet", "Male", true, false, "Yılmaz", null, "555-1234567" },
                    { 2, "Ankara, Türkiye", new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1610), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@example.com", "Ayşe", "Female", true, false, "Demir", null, "555-9876543" },
                    { 3, "İzmir, Türkiye", new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1610), new DateTime(1980, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kara@example.com", "Mehmet", "Male", true, false, "Kara", null, "555-2468101" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(3580), "Admin Rolü, Tüm Haklara Sahiptir.", true, false, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(3590), "Admin" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "IsActive", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(800), 1, true, null, "Dr. Ahmet Yılmaz" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "ModifiedDate", "Name" },
                values: new object[] { 2, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(850), 2, null, "Dr. Ayşe Demir" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "IsActive", "ModifiedDate", "Name" },
                values: new object[] { 3, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(850), 3, true, null, "Dr. Mehmet Kaya" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "ModifiedDate", "Name" },
                values: new object[] { 4, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(860), 1, null, "Dr. Zeynep Çelik" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "IsActive", "ModifiedDate", "Name" },
                values: new object[] { 5, new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(860), 1, true, null, "Dr. Canan Öztürk" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "PasswordHash", "Picture", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(6350), "Sistem yöneticisi", "admin@hospital.com", "Admin", true, false, "User", null, new byte[0], "default.jpg", 1, "admin" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "AppointmentTime", "CreatedDate", "DoctorId", "IsActive", "IsDeleted", "ModifiedDate", "Notes", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 3, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, true, false, null, "Kontrol randevusu", 1 },
                    { 2, new DateTime(2025, 3, 18, 14, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 3, 16, 10, 45, 0, 0, DateTimeKind.Unspecified), 2, true, false, null, "Diyet planı kontrolü", 2 },
                    { 3, new DateTime(2025, 3, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 3, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, true, false, null, "Genel sağlık kontrolü", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

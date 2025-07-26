using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 666, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 666, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 666, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Specialization" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(1490), null });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Specialization" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(1530), null });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Specialization" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(1540), null });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Specialization" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(1540), null });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Specialization" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(1540), null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 667, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 667, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 667, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(4330), new DateTime(2025, 6, 12, 16, 0, 11, 667, DateTimeKind.Local).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 13, 0, 11, 667, DateTimeKind.Utc).AddTicks(7020));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 262, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(3580), new DateTime(2025, 3, 17, 11, 56, 10, 263, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 8, 56, 10, 263, DateTimeKind.Utc).AddTicks(6350));
        }
    }
}

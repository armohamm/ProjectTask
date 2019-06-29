using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTask.Data.Migrations
{
    public partial class changevisitmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doctor_type_id",
                table: "visits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "pacients",
                nullable: false,
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "doctors",
                nullable: false,
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 12);

            migrationBuilder.CreateIndex(
                name: "IX_visits_doctor_type_id",
                table: "visits",
                column: "doctor_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_visits_doctors_type_doctor_type_id",
                table: "visits",
                column: "doctor_type_id",
                principalTable: "doctors_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_doctors_type_doctor_type_id",
                table: "visits");

            migrationBuilder.DropIndex(
                name: "IX_visits_doctor_type_id",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "doctor_type_id",
                table: "visits");

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "pacients",
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "doctors",
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

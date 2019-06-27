using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTask.Data.Migrations
{
    public partial class migrate_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_edit_by",
                table: "pacients");

            migrationBuilder.RenameColumn(
                name: "sur_name",
                table: "pacients",
                newName: "surname");

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "pacients",
                fixedLength: true,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "pacients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_deleted = table.Column<bool>(nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_edit_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IIN = table.Column<string>(fixedLength: true, maxLength: 16, nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctors_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_deleted = table.Column<bool>(nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_edit_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    type_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_deleted = table.Column<bool>(nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_edit_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    doctor_id = table.Column<int>(nullable: false),
                    pacient_id = table.Column<int>(nullable: false),
                    diagnosis = table.Column<string>(nullable: false),
                    complaints = table.Column<string>(nullable: false),
                    visit_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.id);
                    table.ForeignKey(
                        name: "FK_visits_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visits_pacients_pacient_id",
                        column: x => x.pacient_id,
                        principalTable: "pacients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rel_doctor_doctor_type",
                columns: table => new
                {
                    doctor_id = table.Column<int>(nullable: false),
                    doctor_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_doctor_doctor_type", x => new { x.doctor_id, x.doctor_type_id });
                    table.ForeignKey(
                        name: "FK_rel_doctor_doctor_type_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rel_doctor_doctor_type_doctors_type_doctor_type_id",
                        column: x => x.doctor_type_id,
                        principalTable: "doctors_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rel_doctor_doctor_type_doctor_type_id",
                table: "rel_doctor_doctor_type",
                column: "doctor_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_doctor_id",
                table: "visits",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_pacient_id",
                table: "visits",
                column: "pacient_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rel_doctor_doctor_type");

            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropTable(
                name: "doctors_type");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "pacients",
                newName: "sur_name");

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "pacients",
                nullable: true,
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "pacients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "last_edit_by",
                table: "pacients",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_ClinicSystem.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_SpecialistField_specialistFieldId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "fieldId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "specialistFieldId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_SpecialistField_specialistFieldId",
                table: "Doctor",
                column: "specialistFieldId",
                principalTable: "SpecialistField",
                principalColumn: "specialistFieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_SpecialistField_specialistFieldId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "specialistFieldId",
                table: "Doctor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "fieldId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_SpecialistField_specialistFieldId",
                table: "Doctor",
                column: "specialistFieldId",
                principalTable: "SpecialistField",
                principalColumn: "specialistFieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

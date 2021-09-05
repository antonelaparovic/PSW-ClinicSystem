using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_ClinicSystem.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_patientId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "patientId",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_patientId",
                table: "Appointment",
                column: "patientId",
                principalTable: "Patient",
                principalColumn: "patientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_patientId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "patientId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_patientId",
                table: "Appointment",
                column: "patientId",
                principalTable: "Patient",
                principalColumn: "patientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

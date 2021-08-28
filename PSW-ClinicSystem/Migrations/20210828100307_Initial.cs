using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PSW_ClinicSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    hospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.hospitalId);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    medicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    medicineName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.medicineId);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    pharmacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.pharmacyId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistField",
                columns: table => new
                {
                    fieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fieldName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistField", x => x.fieldId);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    adminName = table.Column<string>(type: "text", nullable: true),
                    hospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                    table.ForeignKey(
                        name: "FK_Admin_Hospital_hospitalId",
                        column: x => x.hospitalId,
                        principalTable: "Hospital",
                        principalColumn: "hospitalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacist",
                columns: table => new
                {
                    pharmacistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pharmacistName = table.Column<string>(type: "text", nullable: true),
                    pharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacist", x => x.pharmacistId);
                    table.ForeignKey(
                        name: "FK_Pharmacist_Pharmacy_pharmacyId",
                        column: x => x.pharmacyId,
                        principalTable: "Pharmacy",
                        principalColumn: "pharmacyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doctorName = table.Column<string>(type: "text", nullable: true),
                    hospitalId = table.Column<int>(type: "int", nullable: false),
                    fieldId = table.Column<int>(type: "int", nullable: false),
                    specialistFieldfieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.doctorId);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_hospitalId",
                        column: x => x.hospitalId,
                        principalTable: "Hospital",
                        principalColumn: "hospitalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_SpecialistField_specialistFieldfieldId",
                        column: x => x.specialistFieldfieldId,
                        principalTable: "SpecialistField",
                        principalColumn: "fieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    patientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientName = table.Column<string>(type: "text", nullable: true),
                    selectedDoctordoctorId = table.Column<int>(type: "int", nullable: true),
                    isBlocked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.patientId);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_selectedDoctordoctorId",
                        column: x => x.selectedDoctordoctorId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int", nullable: true),
                    doctorId = table.Column<int>(type: "int", nullable: true),
                    appointmentTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    isConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isRejected = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isTaken = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.appointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    isApproved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    prescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    medicineId = table.Column<int>(type: "int", nullable: false),
                    isUsed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.prescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicine_medicineId",
                        column: x => x.medicineId,
                        principalTable: "Medicine",
                        principalColumn: "medicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    referralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    orderedBy = table.Column<int>(type: "int", nullable: false),
                    orderedByDoctordoctorId = table.Column<int>(type: "int", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    specialistId = table.Column<int>(type: "int", nullable: false),
                    isUsed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.referralId);
                    table.ForeignKey(
                        name: "FK_Referral_Doctor_orderedByDoctordoctorId",
                        column: x => x.orderedByDoctordoctorId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referral_Doctor_specialistId",
                        column: x => x.specialistId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_hospitalId",
                table: "Admin",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_doctorId",
                table: "Appointment",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patientId",
                table: "Appointment",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_hospitalId",
                table: "Doctor",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_specialistFieldfieldId",
                table: "Doctor",
                column: "specialistFieldfieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_patientId",
                table: "Feedback",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_selectedDoctordoctorId",
                table: "Patient",
                column: "selectedDoctordoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacist_pharmacyId",
                table: "Pharmacist",
                column: "pharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_doctorId",
                table: "Prescription",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_medicineId",
                table: "Prescription",
                column: "medicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_patientId",
                table: "Prescription",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_orderedByDoctordoctorId",
                table: "Referral",
                column: "orderedByDoctordoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_patientId",
                table: "Referral",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_specialistId",
                table: "Referral",
                column: "specialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Pharmacist");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "SpecialistField");
        }
    }
}

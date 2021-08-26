﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("PSW_ClinicSystem.Data.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("adminName")
                        .HasColumnType("text");

                    b.Property<int>("hospitalId")
                        .HasColumnType("int");

                    b.HasKey("adminId");

                    b.HasIndex("hospitalId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Appointment", b =>
                {
                    b.Property<int>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("appointmentTime")
                        .HasColumnType("datetime");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<bool>("isConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isRejected")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("appointmentId");

                    b.HasIndex("doctorId");

                    b.HasIndex("patientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Doctor", b =>
                {
                    b.Property<int>("doctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("doctorName")
                        .HasColumnType("text");

                    b.Property<int>("fieldId")
                        .HasColumnType("int");

                    b.Property<int>("hospitalId")
                        .HasColumnType("int");

                    b.Property<int?>("specialistFieldfieldId")
                        .HasColumnType("int");

                    b.HasKey("doctorId");

                    b.HasIndex("hospitalId");

                    b.HasIndex("specialistFieldfieldId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Feedback", b =>
                {
                    b.Property<int>("feedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<bool>("isApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("patientId1")
                        .HasColumnType("int");

                    b.HasKey("feedbackId");

                    b.HasIndex("patientId1");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Hospital", b =>
                {
                    b.Property<int>("hospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("hospitalId");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Medicine", b =>
                {
                    b.Property<int>("medicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("medicineName")
                        .HasColumnType("text");

                    b.HasKey("medicineId");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Patient", b =>
                {
                    b.Property<int>("patientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("patientName")
                        .HasColumnType("text");

                    b.Property<int?>("selectedDoctordoctorId")
                        .HasColumnType("int");

                    b.HasKey("patientId");

                    b.HasIndex("selectedDoctordoctorId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Pharmacist", b =>
                {
                    b.Property<int>("pharmacistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("pharmacistName")
                        .HasColumnType("text");

                    b.Property<int>("pharmacyId")
                        .HasColumnType("int");

                    b.HasKey("pharmacistId");

                    b.HasIndex("pharmacyId");

                    b.ToTable("Pharmacist");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Pharmacy", b =>
                {
                    b.Property<int>("pharmacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("pharmacyId");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Prescription", b =>
                {
                    b.Property<int>("prescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<bool>("isUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("medicineId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("prescriptionId");

                    b.HasIndex("doctorId");

                    b.HasIndex("medicineId");

                    b.HasIndex("patientId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Referral", b =>
                {
                    b.Property<int>("referralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("isUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("orderedBy")
                        .HasColumnType("int");

                    b.Property<int?>("orderedByDoctordoctorId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("specialistId")
                        .HasColumnType("int");

                    b.HasKey("referralId");

                    b.HasIndex("orderedByDoctordoctorId");

                    b.HasIndex("patientId");

                    b.HasIndex("specialistId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.SpecialistField", b =>
                {
                    b.Property<int>("fieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("fieldName")
                        .HasColumnType("text");

                    b.HasKey("fieldId");

                    b.ToTable("SpecialistField");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Admin", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Hospital", "hospital")
                        .WithMany("Admin")
                        .HasForeignKey("hospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hospital");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Appointment", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Doctor", "doctor")
                        .WithMany("appointment")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSW_ClinicSystem.Data.Patient", "patient")
                        .WithMany("appointment")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Doctor", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Hospital", "hospital")
                        .WithMany("Doctor")
                        .HasForeignKey("hospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSW_ClinicSystem.Data.SpecialistField", "specialistField")
                        .WithMany("Doctor")
                        .HasForeignKey("specialistFieldfieldId");

                    b.Navigation("hospital");

                    b.Navigation("specialistField");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Feedback", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Patient", "patientId")
                        .WithMany()
                        .HasForeignKey("patientId1");

                    b.Navigation("patientId");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Patient", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Doctor", "selectedDoctor")
                        .WithMany()
                        .HasForeignKey("selectedDoctordoctorId");

                    b.Navigation("selectedDoctor");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Pharmacist", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Pharmacy", "pharmacy")
                        .WithMany("pharmacist")
                        .HasForeignKey("pharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pharmacy");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Prescription", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Doctor", "doctor")
                        .WithMany("prescription")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSW_ClinicSystem.Data.Medicine", "medicine")
                        .WithMany("prescription")
                        .HasForeignKey("medicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSW_ClinicSystem.Data.Patient", "patient")
                        .WithMany("prescription")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("medicine");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Referral", b =>
                {
                    b.HasOne("PSW_ClinicSystem.Data.Doctor", "orderedByDoctor")
                        .WithMany()
                        .HasForeignKey("orderedByDoctordoctorId");

                    b.HasOne("PSW_ClinicSystem.Data.Patient", "patient")
                        .WithMany("referral")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSW_ClinicSystem.Data.Doctor", "specialist")
                        .WithMany()
                        .HasForeignKey("specialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orderedByDoctor");

                    b.Navigation("patient");

                    b.Navigation("specialist");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Doctor", b =>
                {
                    b.Navigation("appointment");

                    b.Navigation("prescription");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Hospital", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Medicine", b =>
                {
                    b.Navigation("prescription");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Patient", b =>
                {
                    b.Navigation("appointment");

                    b.Navigation("prescription");

                    b.Navigation("referral");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.Pharmacy", b =>
                {
                    b.Navigation("pharmacist");
                });

            modelBuilder.Entity("PSW_ClinicSystem.Data.SpecialistField", b =>
                {
                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}

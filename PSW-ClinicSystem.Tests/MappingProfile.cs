using AutoMapper;
using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_ClinicSystem.DTO;


namespace PSW_ClinicSystem.Tests
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<FeedbackResponseDTO, Feedback>();
            CreateMap<FeedbackDTO, Feedback>();
            CreateMap<Feedback, FeedbackResponseDTO>();

            CreateMap<Task<IEnumerable<FeedbackDTO>>,Task<IActionResult>>();   // for service
            CreateMap<IEnumerable<Feedback>, Task<IEnumerable<FeedbackDTO>>>();   // for service

            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Doctor, DoctorResponseDTO>();
            CreateMap<DoctorResponseDTO, Doctor>();

            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientResponseDTO, Patient>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientResponseDTO>();

            CreateMap<Medicine, MedicineDTO>();
            CreateMap<MedicineResponseDTO, Medicine>();
            CreateMap<MedicineDTO, Medicine>();
            CreateMap<Medicine, MedicineResponseDTO>();

            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionResponseDTO, Prescription>();
            CreateMap<PrescriptionDTO, Prescription>();
            CreateMap<Prescription, PrescriptionResponseDTO>();

            CreateMap<Referral, ReferralDTO>();
            CreateMap<ReferralResponseDTO, Referral>();
            CreateMap<ReferralDTO, Referral>();
            CreateMap<Referral, ReferralResponseDTO>();

            CreateMap<User, UserResponseDTO>();
            CreateMap<UserResponseDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<Admin, AdminResponseDTO>();
            CreateMap<AdminResponseDTO, Admin>();
            CreateMap<AdminDTO, Admin>();
            CreateMap<Admin, AdminDTO>();

            CreateMap<Patient, User>();
            CreateMap<Doctor, User>();
            CreateMap<Admin, User>();

        }
    }
}

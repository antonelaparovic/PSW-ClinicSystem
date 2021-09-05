using AutoMapper;
using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_ClinicSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace PSW_ClinicSystem.DTO
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<FeedbackResponseDTO, Feedback>();
            CreateMap<FeedbackDTO, Feedback>();
            CreateMap<Feedback, FeedbackResponseDTO>().ForMember(i => i.Patient,
                opt => opt.MapFrom(o =>new DataDbContext().Patient.Find(o.patientId)));

            CreateMap<Task<IEnumerable<FeedbackDTO>>,Task<IActionResult>>();   // for service
            CreateMap<IEnumerable<Feedback>, Task<IEnumerable<FeedbackDTO>>>();   // for service

            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Doctor, DoctorResponseDTO>().ForMember(i => i.specialistField,
                opt => opt.MapFrom(o => new DataDbContext().SpecialistField.Find(o.specialistFieldId))); ;
            CreateMap<DoctorResponseDTO, Doctor>();

            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientResponseDTO, Patient>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientResponseDTO>().ForMember(i => i.doctor,
                opt => opt.MapFrom(o => new DataDbContext().Doctor.Find(o.doctorId))); ;

            CreateMap<Medicine, MedicineDTO>();
            CreateMap<MedicineResponseDTO, Medicine>();
            CreateMap<MedicineDTO, Medicine>();
            CreateMap<Medicine, MedicineResponseDTO>();

            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionResponseDTO, Prescription>();
            CreateMap<PrescriptionDTO, Prescription>();
            CreateMap<Prescription, PrescriptionResponseDTO>().ForMember(i => i.patient,
                opt => opt.MapFrom(o => new DataDbContext().Patient.Find(o.patientId)))
                .ForMember(i => i.doctor,
                opt => opt.MapFrom(o => new DataDbContext().Doctor.Find(o.doctorId)))
                .ForMember(i => i.medicine,
                opt => opt.MapFrom(o => new DataDbContext().Medicine.Find(o.medicineId)));

            CreateMap<Referral, ReferralDTO>();
            CreateMap<ReferralResponseDTO, Referral>();
            CreateMap<ReferralDTO, Referral>();
            CreateMap<Referral, ReferralResponseDTO>().ForMember(i => i.patient,
                opt => opt.MapFrom(o => new DataDbContext().Patient.Find(o.patientId)))
                .ForMember(i => i.doctor,
                opt => opt.MapFrom(o => new DataDbContext().Doctor.Find(o.doctorId)))
                .ForMember(i => i.specialist,
                opt => opt.MapFrom(o => new DataDbContext().Doctor.Find(o.specialistId)));

            CreateMap<User, UserResponseDTO>();
            CreateMap<UserResponseDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<Admin, AdminResponseDTO>();
            CreateMap<AdminResponseDTO, Admin>();
            CreateMap<AdminDTO, Admin>();
            CreateMap<Admin, AdminDTO>();

            CreateMap<Appointment, AppointmentResponseDTO>().ForMember(i => i.patient,
                opt => opt.MapFrom(o => new DataDbContext().Patient.Find(o.patientId)))
                .ForMember(i => i.doctor,
                opt => opt.MapFrom(o => new DataDbContext().Doctor.Find(o.doctorId))); ;
            CreateMap<AppointmentResponseDTO, Appointment>();
            CreateMap<AppointmentDTO, Appointment>();
            CreateMap<Appointment, AppointmentDTO>();

            CreateMap<Patient, User>();
            CreateMap<Doctor, User>();
            CreateMap<Admin, User>();

        }
    }
}

using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PSW_ClinicSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository doctorRepository;
        private IMapper mapper; // mapping Db entities to DTOs

        public DoctorService(IDoctorRepository repository, IMapper maper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(doctorRepository), "Repository cannot be null");
            }
            doctorRepository = repository;
            mapper = maper;
        }


        public void CreateDoctor(DoctorDTO doctor)
        {
            var doctorEntity = mapper.Map<Doctor>(doctor);
            doctorRepository.Add(doctorEntity);
            doctorRepository.Save();
        }

        public void DeleteDoctor(int doctorId)
        {
            
                var doctor = doctorRepository.GetById(doctorId);
                
                doctorRepository.Remove(doctor);
                doctorRepository.Save();
        }

        public DoctorResponseDTO GetById(int doctorId)
        {
            var doctor = doctorRepository.GetById(doctorId);

            return mapper.Map<DoctorResponseDTO>(doctor);
        }


        public IEnumerable<DoctorResponseDTO> GetBySpecialistField(int specialistField)
        {
            var specialist = doctorRepository.GetBySpecialistField(specialistField);
            return mapper.Map<IEnumerable<DoctorResponseDTO>>(specialist);
        }

        public IEnumerable<DoctorResponseDTO> GetDoctors()
        {
            var doctors = doctorRepository.GetAll();
            return mapper.Map<IEnumerable<DoctorResponseDTO>>(doctors);
        }
    }
}

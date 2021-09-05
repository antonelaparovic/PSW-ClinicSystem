using AutoMapper;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository patientRepository;
        private IMapper mapper; // mapping Db entities to DTOs

        public PatientService(IPatientRepository repository, IMapper maper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(patientRepository), "Repository cannot be null");
            }
            patientRepository = repository;
            mapper = maper;
        }


        public void CreatePatient(PatientDTO patient)
        {
            var patientEntity = mapper.Map<Patient>(patient);
            patientRepository.Add(patientEntity);
            patientRepository.Save();
        }

        public void DeletePatient(int patientId)
        {

            var patient = patientRepository.GetById(patientId);

            patientRepository.Remove(patient);
            patientRepository.Save();
        }


        public PatientResponseDTO GetById(int patientId)
        {
            var patient = patientRepository.GetById(patientId);

            return mapper.Map<PatientResponseDTO>(patient);
        }

        public IEnumerable<PatientResponseDTO> GetPatients()
        {
            var patients = patientRepository.GetAll();
            return mapper.Map<IEnumerable<PatientResponseDTO>>(patients);
        }

    }
}


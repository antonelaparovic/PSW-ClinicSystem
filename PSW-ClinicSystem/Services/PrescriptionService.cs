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
    public class PrescriptionService : IPrescriptionService
    {
        private IPrescriptionRepository prescriptionRepository;
        private IMapper mapper; // mapping Db entities to DTOs

        public PrescriptionService(IPrescriptionRepository repository, IMapper maper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(prescriptionRepository), "Repository cannot be null");
            }
            prescriptionRepository = repository;
            mapper = maper;
        }


        public void CreatePrescription(PrescriptionDTO prescription)
        {
            var prescriptionEntity = mapper.Map<Prescription>(prescription);
            prescriptionRepository.Add(prescriptionEntity);
            prescriptionRepository.Save();
        }

        public void DeletePrescription(int prescriptionId)
        {

            var prescription = prescriptionRepository.GetById(prescriptionId);

            prescriptionRepository.Remove(prescription);
            prescriptionRepository.Save();
        }


        public PrescriptionResponseDTO GetById(int prescriptionId)
        {
            var prescription = prescriptionRepository.GetById(prescriptionId);

            return mapper.Map<PrescriptionResponseDTO>(prescription);
        }

        public IEnumerable<PrescriptionResponseDTO> GetPrescriptions()
        {
            var prescriptions = prescriptionRepository.GetAll();
            return mapper.Map<IEnumerable<PrescriptionResponseDTO>>(prescriptions);
        }

    }
}

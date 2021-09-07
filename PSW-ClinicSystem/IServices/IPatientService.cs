using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.IServices
{
    public interface IPatientService
    {
        IEnumerable<PatientResponseDTO> GetPatients();
        void CreatePatient(PatientDTO newPatient);
        void DeletePatient(int patientId);
        PatientResponseDTO GetById(int patientId);
        void BlockPatient(int id);
        void UnblockPatient(int id);
        PatientResponseDTO GetByName(string patientName);
    }
}

using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.IServices
{
    public interface IPrescriptionService
    {
        IEnumerable<PrescriptionResponseDTO> GetPrescriptions();
        void CreatePrescription(PrescriptionDTO newPrescription);
        void DeletePrescription(int prescriptionId);
        PrescriptionResponseDTO GetById(int prescriptionId);
    }
}

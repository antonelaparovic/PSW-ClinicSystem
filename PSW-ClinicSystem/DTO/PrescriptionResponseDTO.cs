using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.DTO
{
    public class PrescriptionResponseDTO
    {
        public int prescriptionId { get; set; }
        public PatientResponseDTO patient { get; set; }
        public DoctorResponseDTO doctor { get; set; }
        public MedicineResponseDTO medicine { get; set; }
        public bool isUsed { get; set; }
    }
}

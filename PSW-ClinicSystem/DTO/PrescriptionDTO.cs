using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.DTO
{
    public class PrescriptionDTO
    {
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int medicineId { get; set; }
        public bool isUsed { get; set; }
    }
}

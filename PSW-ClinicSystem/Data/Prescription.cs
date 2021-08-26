using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Prescription
    {
        [Key] public int prescriptionId { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public int medicineId { get; set; }
        public Medicine medicine { get; set; }
        public bool isUsed { get; set; }
    }
}

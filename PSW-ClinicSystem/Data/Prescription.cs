using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Prescription
    {
        [Key] public int prescriptionId { get; set; }

        [ForeignKey("Patient")]
        public int patientId { get; set; }
        public virtual Patient patient { get; set; }

        [ForeignKey("Doctor")]
        public int doctorId { get; set; }
        public virtual Doctor doctor { get; set; }

        [ForeignKey("Medicine")]
        public int medicineId { get; set; }
        public virtual Medicine medicine { get; set; }
        public bool isUsed { get; set; }
    }
}

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

        [ForeignKey("patientId")]
        public virtual Patient patient { get; set; }
        public int patientId { get; set; }

        [ForeignKey("doctorId")]
        public virtual Doctor doctor { get; set; }

        public int doctorId { get; set; }

        [ForeignKey("medicineId")]
        public virtual Medicine medicine { get; set; }
        public int medicineId { get; set; }
        public bool isUsed { get; set; }
    }
}

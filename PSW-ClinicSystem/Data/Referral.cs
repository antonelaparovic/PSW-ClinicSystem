using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Referral
    {
        [Key] public int referralId { get; set; }

        [ForeignKey("doctorId")]
        public virtual Doctor doctor { get; set; }

        public int doctorId { get; set; }      // atm nullable, TO DO change 

        [ForeignKey("patientId")]
        public virtual Patient patient { get; set; }

        public int patientId { get; set; }

        [ForeignKey("specialistId")]
        public virtual Doctor specialist { get; set; }

        public int specialistId { get; set; }   // atm nullable, TO DO change 
        public bool isUsed { get; set; }
    }
}

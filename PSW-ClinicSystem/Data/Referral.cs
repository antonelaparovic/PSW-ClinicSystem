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

        [ForeignKey("Doctor")]
        public int doctorId { get; set; }      // atm nullable, TO DO change 
        public virtual Doctor doctor { get; set; }

        [ForeignKey("Patient")]
        public int patientId { get; set; }
        public virtual Patient patient { get; set; }

        [ForeignKey("Doctor")]
        public int specialistId { get; set; }   // atm nullable, TO DO change 
        public virtual Doctor specialist { get; set; }
        public bool isUsed { get; set; }
    }
}

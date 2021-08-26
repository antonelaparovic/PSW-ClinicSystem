using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Referral
    {
        [Key] public int referralId { get; set; }
        public int orderedBy { get; set; }      // atm nullable, TO DO change 
        public Doctor orderedByDoctor { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public int specialistId { get; set; }   // atm nullable, TO DO change 
        public Doctor specialist { get; set; }
        public bool isUsed { get; set; }
    }
}

using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class ReferralDTO
    {
        public int doctorId { get; set; }      // atm nullable, TO DO change 
        public int patientId { get; set; }
        public int specialistId { get; set; }   // atm nullable, TO DO change 
        public bool isUsed { get; set; }

    }
}

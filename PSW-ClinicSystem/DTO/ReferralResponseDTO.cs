using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class ReferralResponseDTO
    {
        public int referralId { get; set; }
        public DoctorResponseDTO doctor { get; set; }      // atm nullable, TO DO change 
        public PatientResponseDTO patient { get; set; }
        public DoctorDTO specialist { get; set; }   // atm nullable, TO DO change 
        public bool isUsed { get; set; }

    }
}

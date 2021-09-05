using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class PatientDTO
    {
        public string name { get; set; }
        public int doctorId { get; set; }
        public bool isBlocked { get; set; }
        public string Password { get; set; }

    }
}

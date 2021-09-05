using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class DoctorDTO
    {
        public string name { get; set; }
        public int hospitalId { get; set; } 
        public int specialistFieldId { get; set; }
        public string Password { get; set; }

    }
}

using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class PatientResponseDTO
    {
        public int patientId { get; set; }
        public string name { get; set; }
        public DoctorResponseDTO doctor { get; set; }
        public bool isBlocked { get; set; }
        public string Password { get; set; }

    }
}

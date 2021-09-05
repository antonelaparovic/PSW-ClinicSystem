using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class DoctorResponseDTO
    {
        public int doctorId { get; set; }
        public string name { get; set; }
        public int hospitalId { get; set; }
        public SpecialistField specialistField { get; set; }
        public string Password { get; set; }

    }
}

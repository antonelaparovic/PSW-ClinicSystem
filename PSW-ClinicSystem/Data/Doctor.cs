using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Doctor
    {
        [Key] public int doctorId { get; set; }
        public string doctorName { get; set; }
        public int hospitalId { get; set; }     // not null
        public Hospital hospital { get; set; }

        public int fieldId { get; set; }       // not null
        public SpecialistField specialistField { get; set; }
        public ICollection<Appointment> appointment { get; set; } // not null
        public ICollection<Prescription> prescription { get; set; }  // not null
    }
}

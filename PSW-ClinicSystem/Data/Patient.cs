using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Patient
    {
        [Key] public int patientId { get; set; }
        public string patientName { get; set; }
        public Doctor selectedDoctor { get; set; }    // nullable fk
        public bool isBlocked { get; set; }
        public ICollection<Appointment> appointment { get; set; }  
        public ICollection<Prescription> prescription { get; set; }
        public ICollection<Referral> referral { get; set; }
        public ICollection<Feedback> feedback { get; set;  }

    }
}

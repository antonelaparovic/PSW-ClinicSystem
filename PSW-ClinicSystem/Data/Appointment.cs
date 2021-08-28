using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Appointment
    {
        [Key] public int appointmentId { get; set;  }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public DateTime appointmentTime { get; set; }
        public bool isConfirmed { get; set; }
        public bool isRejected { get; set; }
        public bool isTaken { get; set; }
    }
}

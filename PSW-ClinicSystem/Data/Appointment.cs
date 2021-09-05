using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Appointment
    {
        [Key] public int appointmentId { get; set;  }

        [ForeignKey("patientId")]
        public virtual Patient patient { get; set; }

        public int? patientId { get; set; }     // to be nullable for initial free appointments in Db

        [ForeignKey("doctorId")]
        public virtual Doctor doctor { get; set; }
        public int doctorId { get; set; }
        public DateTime appointmentTime { get; set; }
        public bool isConfirmed { get; set; }
        public bool isRejected { get; set; }
        public bool isTaken { get; set; }
        public bool priority { get; set; }   // 0 for doctor, 1 for time
    }
}

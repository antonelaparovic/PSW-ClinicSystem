using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Patient
    {
        [Key] public int patientId { get; set; }
        public string name { get; set; }

        [ForeignKey("Doctor")]
        public int doctorId { get; set; }
        public virtual Doctor doctor { get; set; }    // nullable fk
        public bool isBlocked { get; set; }
        public ICollection<Prescription> prescription { get; set; }
        public ICollection<Referral> referral { get; set; }
        public ICollection<Feedback> feedback { get; set;  }
        public string role { get; set; } // always patient

        [JsonIgnore]
        public string Password { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Doctor 
    {
        [Key] public int doctorId { get; set; }
        public string name { get; set; }

        [ForeignKey("Hospital")]
        public int hospitalId { get; set; }     // not null
        public virtual Hospital hospital { get; set; }

        [ForeignKey("SpecialistField")]
        public int specialistFieldId { get; set; }       // not null
        public virtual SpecialistField specialistField { get; set; }

        public ICollection<Prescription> prescription { get; set; }  // not null
        public string role { get; set; } // always doctor

        [JsonIgnore]
        public string Password { get; set; }
    }
}

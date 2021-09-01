using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Pharmacist
    {
        [Key] public int pharmacistId { get; set; }
        public string name { get; set; }

        [ForeignKey("Pharmacy")]
        public int pharmacyId { get; set; }
        public virtual Pharmacy pharmacy { get; set; }  // not null one to many
        public Role role { get; set; } // always pharmacist

        [JsonIgnore]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Pharmacist
    {
        [Key] public int pharmacistId { get; set; }
        public string pharmacistName { get; set; }
        public int pharmacyId { get; set; }
        public Pharmacy pharmacy { get; set; }  // not null one to many
    }
}

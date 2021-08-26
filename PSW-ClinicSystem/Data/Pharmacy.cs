using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Pharmacy
    {
        [Key] public int pharmacyId { get; set; }
        public ICollection<Pharmacist> pharmacist { get; set; }
    }
}

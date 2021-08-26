using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Medicine
    {
        [Key] public int medicineId { get; set; }
        public string medicineName { get; set; }
        public ICollection<Prescription> prescription { get; set; }
    }
}

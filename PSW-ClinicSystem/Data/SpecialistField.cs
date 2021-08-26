using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class SpecialistField
    {
        [Key] public int fieldId { get; set; }
        public string fieldName { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
    }
}

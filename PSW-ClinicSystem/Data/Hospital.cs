using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Hospital
    {
        [Key] public int hospitalId { get; set; }
        public ICollection<Admin> Admin { get; set; }  // not nullable
        public ICollection<Doctor> Doctor { get; set; }  // not nullable


    }
}

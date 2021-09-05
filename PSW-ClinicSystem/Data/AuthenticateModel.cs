using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class AuthenticateModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

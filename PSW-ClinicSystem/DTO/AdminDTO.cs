using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class AdminDTO
    {
        public string name { get; set; }   // same in users

        public int hospitalId { get; set; }
        public string role { get; set; } // always admin
        public string Password { get; set; }
    }
}

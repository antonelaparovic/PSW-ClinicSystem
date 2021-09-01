using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Admin
    {
        [Key] public int adminId { get; set; }
        public string name { get; set; }   // same in users

        [ForeignKey("Hospital")]
        public int hospitalId { get; set; }
        public virtual Hospital hospital { get; set; }   // not nullable 
        public string role { get; set; } // always admin
        [JsonIgnore]
        public string Password { get; set; }
    }
}

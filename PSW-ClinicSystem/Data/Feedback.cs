using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Feedback
    {
        [Key] public int feedbackId { get; set; }
        public int patientId { get; set; }  
        public Patient patient { get; set; }
        public string content { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }
    }
}

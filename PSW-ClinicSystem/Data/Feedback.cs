using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class Feedback
    {
        public Feedback(int patientId, string content, bool isApproved, bool isDeleted)
        {
            this.patientId = patientId;
            this.content = content;
            this.isApproved = isApproved;
            this.isDeleted = isDeleted;
        }
        public Feedback() { }

        [Key] public int feedbackId { get; set; }

        [ForeignKey("patientId")]    // Patient
        public virtual Patient patient { get; set; }
        public int patientId { get; set; }  
        public string content { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }
    }
}

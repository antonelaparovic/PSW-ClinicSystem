using PSW_ClinicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.DTO
{
    public class FeedbackResponseDTO
    {
        public int FeedbackId { get; set; }
        public Patient Patient { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Repository
{
    public class ReferralRepository : Repository<Referral>, IReferralRepository
    {
        public ReferralRepository(DataDbContext context) : base(context)
        {
        }

        public IEnumerable<Referral> GetByPatient(Patient patient)
        {
            return DataDbContext.Referral.Where(x => x.patient.patientId == patient.patientId).ToList(); ;
        }
    }
}
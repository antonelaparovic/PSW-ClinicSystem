using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Interfaces
{
    public interface IReferralRepository : IRepository<Referral>
    {
        IEnumerable<Referral> GetByPatient(Patient patient);

    }
}
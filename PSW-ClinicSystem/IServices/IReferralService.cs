using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.IServices
{
    public interface IReferralService
    {
        IEnumerable<ReferralResponseDTO> GetReferrals();
        void CreateReferral(ReferralDTO newReferral);
        void DeleteReferral(int referralId);
        ReferralResponseDTO GetById(int referralId);
        IEnumerable<ReferralResponseDTO> GetForPatient(string patientName);

    }
}

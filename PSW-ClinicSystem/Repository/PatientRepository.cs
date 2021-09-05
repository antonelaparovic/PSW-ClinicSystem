using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Repository
{
    public class PatientRepository: Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DataDbContext context) : base(context)
        {

            
        }
    }
}

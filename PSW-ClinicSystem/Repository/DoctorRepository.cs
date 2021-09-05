using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DataDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Doctor> GetBySpecialistField(int specialistField)
        {
            return DataDbContext.Doctor.Where(x => x.specialistField.specialistFieldId == specialistField).ToList(); ;
        }
    }
}
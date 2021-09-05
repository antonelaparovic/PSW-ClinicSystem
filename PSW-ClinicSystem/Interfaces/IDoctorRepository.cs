using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetBySpecialistField(int specialistField);
    }
}

using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.IServices
{
    public interface IDoctorService
    {
        IEnumerable<DoctorResponseDTO> GetDoctors();
        void CreateDoctor(DoctorDTO newDoctor);
        void DeleteDoctor(int doctorId);
        DoctorResponseDTO GetById(int docotrId);
        IEnumerable<DoctorResponseDTO> GetBySpecialistField(int specialistField);
    }
}

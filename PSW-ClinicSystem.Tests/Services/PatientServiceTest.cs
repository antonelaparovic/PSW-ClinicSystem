using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NSubstitute;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using PSW_ClinicSystem.Services;
using System.Linq;
using Xunit;

namespace PSW_ClinicSystem.Tests.Services
{
    public class PatientServiceTest
    {
        private readonly IPatientService patientService;
        private readonly IPatientRepository patientRepository = Substitute.For<IPatientRepository>();
        private readonly IMapper _mapper;

        public PatientServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            patientService = new PatientService(patientRepository, _mapper);
        }

        [Fact]
        public void GetAllPatient_RequestListOfObjects_ReturnsAreEqual()
        {
            List<Patient> fbList = new List<Patient>()
            {
            new Patient { patientId = 1, name = "MM", doctorId = 1, isBlocked = false, role = "Patient", Password="patient1" }
            };

            patientRepository.GetAll().Returns(fbList);
            IEnumerable<PatientResponseDTO> patients = patientService.GetPatients();

            Assert.Equal(fbList.Count, patients.ToList().Count);
        }

    }
}

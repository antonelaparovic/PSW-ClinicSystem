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
    public class DoctorServiceTest
    {
        private readonly IDoctorService doctorService;
        private readonly IDoctorRepository doctorRepository = Substitute.For<IDoctorRepository>();
        private readonly IMapper _mapper;

        public DoctorServiceTest()
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
            doctorService = new DoctorService(doctorRepository, _mapper);
        }

        [Fact]
        public void GetAllDoctor_RequestListOfObjects_ReturnsAreEqual()
        {
            List<Doctor> fbList = new List<Doctor>()
            {
            new Doctor { doctorId = 1, name = "MM", hospitalId = 1, specialistFieldId = 2, role = "Doctor", Password="doctor1" }
            };

            doctorRepository.GetAll().Returns(fbList);
            IEnumerable<DoctorResponseDTO> doctors = doctorService.GetDoctors();

            Assert.Equal(fbList.Count, doctors.ToList().Count);
        }

        [Fact]
        public void GetBySpecialistField_RequestListOfObjects_ReturnsCorrect()
        {
            List<Doctor> fbList = new List<Doctor>()
            {
            new Doctor { doctorId = 1, name = "MM", hospitalId = 1, specialistFieldId = 2, role = "Doctor", Password="doctor1" }
            };

            doctorRepository.GetBySpecialistField(2).Returns(fbList);
            IEnumerable<DoctorResponseDTO> doctors = doctorService.GetBySpecialistField(2);

            Assert.Equal(fbList.Count, doctors.ToList().Count);
        }

    }
}


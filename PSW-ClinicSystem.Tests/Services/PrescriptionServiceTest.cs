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
    public class PrescriptionServiceTest
    {

        private readonly IPrescriptionService prescriptionService;
        private readonly IPrescriptionRepository prescriptionRepository = Substitute.For<IPrescriptionRepository>();
        private readonly IMapper _mapper;

        public PrescriptionServiceTest()
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
            prescriptionService = new PrescriptionService(prescriptionRepository, _mapper);
        }

        [Fact]
        public void GetAllPrescription_RequestListOfObjects_ReturnsAreEqual()
        {
            List<Prescription> fbList = new List<Prescription>()
            {
            new Prescription { prescriptionId = 1, patientId=1, doctorId = 1, medicineId = 2, isUsed=true }
            };

            prescriptionRepository.GetAll().Returns(fbList);
            IEnumerable<PrescriptionResponseDTO> prescriptions = prescriptionService.GetPrescriptions();

            Assert.Equal(fbList.Count, prescriptions.ToList().Count);
        }

        [Fact]
        public void GetAllPrescription_RequestListOfObjects_ReturnsNotEqual()
        {
            List<Prescription> fbList = new List<Prescription>()
            {
            new Prescription { prescriptionId = 1, patientId=1, doctorId = 1, medicineId = 2, isUsed=true }
            };

            prescriptionRepository.GetAll().Returns(fbList);
            IEnumerable<PrescriptionResponseDTO> prescriptions = prescriptionService.GetPrescriptions();

            Assert.NotEqual(3, prescriptions.ToList().Count);
        }

    }
}

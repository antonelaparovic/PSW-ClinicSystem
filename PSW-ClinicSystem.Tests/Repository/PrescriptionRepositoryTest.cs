using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Repository;
using System.Text;
using Xunit;
using System.Linq;

namespace PSW_ClinicSystem.Tests.Repository
{
    public class PrescriptionRepositoryTest
    {
        private readonly IPrescriptionRepository prescriptionRepository = CreateStubPrescriptionRepository();

        [Fact]
        public void GetAllPrescriptions_ReturnsCorrect()
        {

            List<Prescription> prescriptions = prescriptionRepository.GetAll().ToList();
            Assert.NotNull(prescriptions);
        }

        [Fact]
        public void GetAllPrescriptions_ReturnsFail()
        {

            List<Prescription> prescriptions = prescriptionRepository.GetAll().ToList();
            Assert.NotEqual(5, prescriptions.Count);
        }



        private static IPrescriptionRepository CreateStubPrescriptionRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();
            var prescriptions = new List<Prescription>();


            Prescription prescription1 = new Prescription();
            prescription1.patientId = 1;
            prescription1.doctorId = 2;
            prescription1.medicineId = 1;
            prescription1.isUsed = false;

            prescriptions.Add(prescription1);

            Prescription prescription2 = new Prescription();
            prescription2.patientId = 1;
            prescription2.doctorId = 2;
            prescription2.medicineId = 1;
            prescription2.isUsed = false;
            
            prescriptions.Add(prescription2);

            stubRepository.Setup(repo => repo.GetAll()).Returns(prescriptions);
            stubRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Prescription() { prescriptionId = 1 }).Verifiable();

            return stubRepository.Object;

        }
    }
}

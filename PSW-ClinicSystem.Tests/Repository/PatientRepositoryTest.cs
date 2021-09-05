using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Repository;
using System.Linq;
using Xunit;

namespace PSW_ClinicSystem.Tests.Repository
{
    class PatientRepositoryTest
    {
		private readonly IPatientRepository doctorRepository = CreateStubPatientRepository();


		[Fact]
		public void GetAll_ReturnsCorrect()
		{
			List<Patient> patients = patientRepository.GetAll().ToList();
			Assert.NotNull(patients);

		}


		private static IPatientRepository CreateStubPatientRepository()
		{
			var stubRepository = new Mock<IPatientRepository>();
			var patients = new List<Patient>();


			Patient patient1 = new Patient();
			patient1.name = "patient1name";
			patient1.doctorId = 2;
			patient1.isBlocked = false;
			patient1.role = "Patient";
			patient1.Password = "password";

			patients.Add(patient1);

			Patient patient2 = new Patient();
			patient2.name = "patient2name";
			patient2.doctorId = 2;
			patient2.isBlocked = 1;
			patient2.role = "Patient";
			patient2.Password = "password2";

			patients.Add(patient2);

			stubRepository.Setup(repo => repo.GetAll()).Returns(patients);
			stubRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Patient() { patientId = 1 }).Verifiable();

			return stubRepository.Object;

		}
	}
}

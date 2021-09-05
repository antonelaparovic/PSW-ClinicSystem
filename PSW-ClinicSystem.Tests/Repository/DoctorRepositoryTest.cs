using Microsoft.EntityFrameworkCore;
using Moq;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PSW_ClinicSystem.Tests.Repository
{
    public class DoctorRepositoryTest
    {
        private readonly IDoctorRepository doctorRepository = CreateStubDoctorRepository();


        [Fact]
        public void GetAll_ReturnsCorrect()
        {
            // Arrange
            var testObject = new Doctor { doctorId = 1, name = "MM", hospitalId = 1, specialistFieldId = 2, role = "Doctor", Password="doctor1" };
            var testList = new List<Doctor>() { testObject };

            var dbSetMock = new Mock<DbSet<Doctor>>();
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DataDbContext>();
            context.Setup(x => x.Set<Doctor>()).Returns(dbSetMock.Object);

            // Act
            var repository = new DoctorRepository(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.Equal(testList, result.ToList());

        }

        [Fact]
        public void GetAll_ReturnsFail()
        {
            // Arrange
            var testObject1 = new Doctor { doctorId = 1, name = "MM", hospitalId = 1, specialistFieldId = 2, role = "Doctor", Password = "doctor1" };
            var  testObject2 = new Doctor { doctorId = 2, name = "NN", hospitalId = 1, specialistFieldId = 2, role = "Doctor", Password = "doctor2" };
            var testList = new List<Doctor>() { testObject1 };
            var falseList = new List<Doctor>() { testObject2 };

            var dbSetMock = new Mock<DbSet<Doctor>>();
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Doctor>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DataDbContext>();
            context.Setup(x => x.Set<Doctor>()).Returns(dbSetMock.Object);

            // Act
            var repository = new DoctorRepository(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.NotEqual(falseList, result.ToList());

        }

        [Fact]
        public void GetAllDoctors_ReturnsCorrect()
        {
            
            List<Doctor> doctors = doctorRepository.GetAll().ToList();
            Assert.NotNull(doctors);
        }

        [Fact]
        public void GetBySpecialistField_ReturnsCorrect()
        {

            List<Doctor> doctors = doctorRepository.GetBySpecialistField(1).ToList();
            Assert.NotNull(doctors);
        }

        private static IDoctorRepository CreateStubDoctorRepository()
		{
			var stubRepository = new Mock<IDoctorRepository>();
			var doctors = new List<Doctor>();


			Doctor doctor1 = new Doctor();
			doctor1.name = "doctor1name";
            doctor1.hospitalId = 2;
            doctor1.specialistFieldId = 2;
            doctor1.role = "Doctor";
			doctor1.Password = "password";
			
			doctors.Add(doctor1);

			Doctor doctor2 = new Doctor();
            doctor2.name = "doctor2name";
            doctor2.hospitalId = 2;
            doctor2.specialistFieldId = 1;
            doctor2.role = "Doctor";
            doctor2.Password = "password2";
            
            doctors.Add(doctor2);

			stubRepository.Setup(repo => repo.GetAll()).Returns(doctors);
			stubRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Doctor() { doctorId = 1, specialistFieldId = 1 }).Verifiable();
			stubRepository.Setup(repo => repo.GetBySpecialistField(1)).Returns(new List<Doctor>() { doctor2});

			return stubRepository.Object;

		}
	}

}


using System;
using System.Collections.Generic;
using System.Text;
using PSW_ClinicSystem.Repository;
using PSW_ClinicSystem.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Moq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;

namespace PSW_ClinicSystem.Tests.Repository
{
    public class FeedbackRepositoryTest
    {
        
        [Fact]
        public  void GetAll_ReturnsCorrect()
        {
            // Arrange
            var testObject = new Feedback { feedbackId = 1, patientId = 1, content = "ulala", isApproved = true, isDeleted = false };
            var testList = new List<Feedback>() { testObject };

            var dbSetMock = new Mock<DbSet<Feedback>>();
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DataDbContext>();
            context.Setup(x => x.Set<Feedback>()).Returns(dbSetMock.Object);

            // Act
            var repository = new FeedbackRepository(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.Equal(testList, result.ToList());
        
        }

        [Fact]
        public void GetAll_ReturnsFail()
        {
            // Arrange
            var testObject = new Feedback { feedbackId = 1, patientId = 1, content = "ulala", isApproved = true, isDeleted = false };
            var falseObject = new Feedback { feedbackId = 1, patientId = 1, content = "lalala", isApproved = true, isDeleted = false };
            var testList = new List<Feedback>() { testObject };
            var falseList = new List<Feedback>() { falseObject };

            var dbSetMock = new Mock<DbSet<Feedback>>();
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DataDbContext>();
            context.Setup(x => x.Set<Feedback>()).Returns(dbSetMock.Object);

            // Act
            var repository = new FeedbackRepository(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.NotEqual(falseList, result.ToList());

        }

        [Fact]
        public void GetPublished_ReturnsOne()
        {
            // Arrange
            var testObject = new Feedback { feedbackId = 1, patientId = 1, content = "ulala", isApproved = false, isDeleted = false };
            var pubObject = new Feedback { feedbackId = 2, patientId = 1, content = "lalala", isApproved = true, isDeleted = false };
            var testList = new List<Feedback>() { testObject, pubObject };
            var pubList = new List<Feedback>() { pubObject };

            var dbSetMock = new Mock<DbSet<Feedback>>();
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Feedback>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DataDbContext>();
            context.Setup(x => x.Set<Feedback>()).Returns(dbSetMock.Object);

            // Act
            var repository = new FeedbackRepository(context.Object);
            var result = repository.GetUnpublished();

            Assert.Equal(pubList, result);

        }

        [Fact]
        public void GetById_ReturnsCorrect()
        {
            // Arrange
            var testObject = new Feedback();

            var context = new Mock<DataDbContext>();
            var dbSetMock = new Mock<DbSet<Feedback>>();

            context.Setup(x => x.Set<Feedback>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(testObject);

            // Act
            var repository = new FeedbackRepository(context.Object);
            repository.GetById(1);

            // Assert
            context.Verify(x => x.Set<Feedback>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));

        }

    }
}


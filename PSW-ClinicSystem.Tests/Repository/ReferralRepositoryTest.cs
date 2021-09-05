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
    public class ReferralRepositoryTest
    {

		private readonly IReferralRepository referralRepository = CreateStubReferralRepository();


		[Fact]
		public void GetAll_ReturnsCorrect()
		{
			List<Referral> referrals = referralRepository.GetAll().ToList();
			Assert.NotNull(referrals);

		}


		private static IReferralRepository CreateStubReferralRepository()
		{
			var stubRepository = new Mock<IReferralRepository>();
			var referrals = new List<Referral>();


			Referral referral1 = new Referral();
			referral1.doctorId = 1;
			referral1.patientId = 2;
			referral1.specialistId = 1;
			referral1.isUsed = true;

			referrals.Add(referral1);

			Referral referral2 = new Referral();
			referral2.doctorId = 2;
			referral2.patientId = 2;
			referral2.specialistId = 1;
			referral2.isUsed = false;

			referrals.Add(referral2);

			stubRepository.Setup(repo => repo.GetAll()).Returns(referrals);
			stubRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Referral() { referralId = 1 }).Verifiable();

			return stubRepository.Object;

		}
	}
}


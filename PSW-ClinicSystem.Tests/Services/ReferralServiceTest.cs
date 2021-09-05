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
    public class ReferralServiceTest
    {
        private readonly IReferralService referralService;
        private readonly IReferralRepository referralRepository = Substitute.For<IReferralRepository>();
        private readonly IMapper _mapper;

        public ReferralServiceTest()
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
            referralService = new ReferralService(referralRepository, _mapper);
        }

        [Fact]
        public void GetAllReferral_RequestListOfObjects_ReturnsAreEqual()
        {
            List<Referral> fbList = new List<Referral>()
            {
            new Referral { referralId = 1, doctorId=1, patientId = 1, specialistId = 2, isUsed=true }
            };

            referralRepository.GetAll().Returns(fbList);
            IEnumerable<ReferralResponseDTO> referrals = referralService.GetReferrals();

            Assert.Equal(fbList.Count, referrals.ToList().Count);
        }
    }
}

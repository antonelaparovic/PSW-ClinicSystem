using AutoMapper;
using NSubstitute;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using PSW_ClinicSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace PSW_ClinicSystem.Tests.Services
{
    public class FeedbackServiceTest
    {
        private readonly IFeedbackService feedbackService;
        private readonly IFeedbackRepository feedbackRepository = Substitute.For<IFeedbackRepository>();
        private readonly IMapper _mapper;

        public FeedbackServiceTest()
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
            feedbackService = new FeedbackService(feedbackRepository, _mapper);
        }

        [Fact]
        public void GetAllFeedback_RequestListOfObjects_ReturnsAreEqual()
        {
            List<Feedback> fbList = new List<Feedback>()
            {
               new Feedback { feedbackId = 2, patientId = 1, content = "lalala", isApproved = true, isDeleted = false }
        };

            feedbackRepository.GetAll().Returns(fbList);
            IEnumerable<FeedbackResponseDTO> feedbacks = feedbackService.GetFeedbacks();

            Assert.Equal(fbList.Count, feedbacks.ToList().Count);
        }

        [Fact]
        public void GetPublished_RequestListOfObjects_ReturnsAreEqual()
        {
            
            List<Feedback> pubList = new List<Feedback>() {  new Feedback { feedbackId = 2, patientId = 1, content = "lalala", isApproved = true, isDeleted = false } };


            feedbackRepository.GetPublished().Returns(pubList);
            IEnumerable<FeedbackResponseDTO> feedbacks = feedbackService.GetPublished();

            Assert.Equal(1, feedbacks.ToList().Count);
        }

        [Fact]
        public void GetUnpublished_RequestListOfObjects_ReturnsNotEqual()
        {

            List<Feedback> unpubList = new List<Feedback>() { new Feedback { feedbackId = 2, patientId = 1, content = "lalala", isApproved = false, isDeleted = false } };


            feedbackRepository.GetPublished().Returns(unpubList);
            IEnumerable<FeedbackResponseDTO> feedbacks = feedbackService.GetUnpublished();

            Assert.NotEqual(1, feedbacks.ToList().Count);
        }

    }
}

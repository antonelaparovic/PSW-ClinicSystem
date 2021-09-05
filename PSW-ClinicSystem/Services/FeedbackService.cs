using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.IServices;
using AutoMapper;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.DTO;

namespace PSW_ClinicSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository feedbackRepository;
        private IMapper mapper; // mapping Db entities to DTOs

        public FeedbackService(IFeedbackRepository repository, IMapper maper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(feedbackRepository), "Repository cannot be null");
            }
            feedbackRepository = repository;
            mapper = maper;
        }


        public void CreateFeedback(FeedbackDTO feedback)
        {
            var feedbackEntity = mapper.Map<Feedback>(feedback);
            feedbackRepository.Add(feedbackEntity);
            feedbackRepository.Save();
        }

        public void DeleteFeedback(int feedbackId)
        {

            var feedback = feedbackRepository.GetById(feedbackId);

            feedbackRepository.Remove(feedback);
            feedbackRepository.Save();
        }

        public FeedbackResponseDTO GetById(int feedbackId)
        {
            var feedback = feedbackRepository.GetById(feedbackId);

            return mapper.Map<FeedbackResponseDTO>(feedback);
        }

        public IEnumerable<FeedbackResponseDTO> GetFeedbacks()
        {
            var feedbacks = feedbackRepository.GetAll();
            return mapper.Map<IEnumerable<FeedbackResponseDTO>>(feedbacks);
        }

        public IEnumerable<FeedbackResponseDTO> GetPublished()
        {
            var feedbacks = feedbackRepository.GetPublished();
            return mapper.Map<IEnumerable<FeedbackResponseDTO>>(feedbacks);
        }

        public IEnumerable<FeedbackResponseDTO> GetUnpublished()
        {
            var feedbacks = feedbackRepository.GetUnpublished();
            return mapper.Map<IEnumerable<FeedbackResponseDTO>>(feedbacks);
        }

        public void ShareFeedback(int id)
        {
            feedbackRepository.ShareFeedback(id);
        }
    }
}

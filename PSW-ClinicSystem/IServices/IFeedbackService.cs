using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.IServices
{
    public interface IFeedbackService
    {
        IEnumerable<FeedbackResponseDTO> GetFeedbacks();
        void CreateFeedback(FeedbackDTO newFeedback);
        void DeleteFeedback(int feedbackId);
        FeedbackResponseDTO GetById(int feedbackId);
        void ShareFeedback(int id);
        IEnumerable<FeedbackResponseDTO> GetPublished();
        IEnumerable<FeedbackResponseDTO> GetUnpublished();
    }
}

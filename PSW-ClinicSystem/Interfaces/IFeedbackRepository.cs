using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Repository;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        void ShareFeedback(int id);
        IEnumerable<Feedback> GetPublished();
        IEnumerable<Feedback> GetUnpublished();

    }
}

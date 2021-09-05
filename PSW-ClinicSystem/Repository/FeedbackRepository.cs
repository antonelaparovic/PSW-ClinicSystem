using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private DataDbContext _context;
        public FeedbackRepository(DataDbContext context) : base(context)
        {
            _context = context;
        }
       
        public IEnumerable<Feedback> GetPublished()
        {
            return this.DataDbContext.Feedback.Where(x => x.isApproved == true && x.isDeleted == false).ToList();
        }

        public IEnumerable<Feedback> GetUnpublished()
        {
            return this._context.Feedback.Where(x => x.isApproved == false && x.isDeleted == false).ToList();
        }

        public void ShareFeedback(int id)
        {
            var fb = DataDbContext.Feedback.Where(x => x.feedbackId == id && x.isDeleted == false);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurMeetingPoint.Models;

namespace OurMeetingPoint.DAL
{
    public class ReviewRepoEF : IReviewRepo
    {
        private Context _context;

        public ReviewRepoEF(Context context)
        {
            _context = context;
        }

        public void Create(Review item)
        {
            _context.Reviews.Add(item);
        }

        public void Delete(int id)
        {
            Review review = _context.Reviews.Find(id);
            _context.Reviews.Remove(review);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ReviewDetail GetItemById(int id)
        {
            Review review = _context.Reviews.Find(id);
            ReviewDetail reviewDetail = new ReviewDetail()
            {
                ID = review.ID,
                Title = review.Title,
                Description = review.Description,
                Rate = review.Rate,
                MeetingPoint = _context.MeetingPoints.Find(review.MeetingPointID)
            };

            return reviewDetail;
        }

        public IEnumerable<ReviewDetail> GetItems()
        {
            List<ReviewDetail> reviewDetails = new List<ReviewDetail>();
            List<Review> reviews = _context.Reviews.ToList();

            reviews.ForEach(e => reviewDetails.Add(new ReviewDetail() {
                ID = e.ID,
                Title = e.Title,
                Description = e.Description,
                Rate = e.Rate,
                MeetingPoint = _context.MeetingPoints.Find(e.MeetingPointID)
            }));

            return reviewDetails;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Review item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
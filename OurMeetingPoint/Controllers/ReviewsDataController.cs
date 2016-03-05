using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OurMeetingPoint.Models;
using OurMeetingPoint.DAL;

namespace OurMeetingPoint.Controllers
{
    public class ReviewsDataController : ApiController
    {
        private IReviewRepo _repo;

        public ReviewsDataController()
        {
            _repo = new ReviewRepoEF(new Context());
        }

        // GET: api/ReviewsData
        public IEnumerable<ReviewDetail> GetReviews()
        {
            return _repo.GetItems();
        }

        // GET: api/ReviewsData/5
        [ResponseType(typeof(ReviewDetail))]
        public IHttpActionResult GetReview(int id)
        {
            ReviewDetail review = _repo.GetItemById(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/ReviewsData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, Review review)
        {
            ReviewDetail oldReview = _repo.GetItemById(id);

            if(oldReview == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ID)
            {
                return BadRequest();
            }

            _repo.Update(review);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReviewsData
        [ResponseType(typeof(ReviewDetail))]
        public IHttpActionResult PostReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(review);
            _repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = review.ID }, review);
        }

        // DELETE: api/ReviewsData/5
        [ResponseType(typeof(ReviewDetail))]
        public IHttpActionResult DeleteReview(int id)
        {
            ReviewDetail review = _repo.GetItemById(id);
            if (review == null)
            {
                return NotFound();
            }

            _repo.Delete(id);
            _repo.Save();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
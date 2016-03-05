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
    public class MeetingPointsDataController : ApiController
    {
        private IMeetingPointRepo _repo;

        public MeetingPointsDataController()
        {
            _repo = new MeetingPointRepoEF(new Context());
        }

        // GET: api/MeetingPointsData
        public IEnumerable<MeetingPointDetail> GetMeetingPoints()
        {
            return _repo.GetItems();
        }

        // GET: api/MeetingPointsData/5
        [ResponseType(typeof(MeetingPointDetail))]
        public IHttpActionResult GetMeetingPoint(int id)
        {
            MeetingPointDetail meetingPoint = _repo.GetItemById(id);
            if (meetingPoint == null)
            {
                return NotFound();
            }

            return Ok(meetingPoint);
        }

        // PUT: api/MeetingPointsData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeetingPoint(int id, MeetingPoint meetingPoint)
        {
            MeetingPointDetail oldMeetingPoint = _repo.GetItemById(id);

            if(oldMeetingPoint == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meetingPoint.ID)
            {
                return BadRequest();
            }

            _repo.Update(meetingPoint);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MeetingPointsData
        [ResponseType(typeof(MeetingPointDetail))]
        public IHttpActionResult PostMeetingPoint(MeetingPoint meetingPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(meetingPoint);
            _repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = meetingPoint.ID }, meetingPoint);
        }

        // DELETE: api/MeetingPointsData/5
        [ResponseType(typeof(MeetingPointDetail))]
        public IHttpActionResult DeleteMeetingPoint(int id)
        {
            MeetingPointDetail meetingPoint = _repo.GetItemById(id);
            if (meetingPoint == null)
            {
                return NotFound();
            }

            _repo.Delete(id);
            _repo.Save();

            return Ok(meetingPoint);
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
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

namespace OurMeetingPoint.Controllers
{
    public class MeetingPointsDataController : ApiController
    {
        private Context db = new Context();

        // GET: api/MeetingPointsData
        public IQueryable<MeetingPoint> GetMeetingPoints()
        {
            return db.MeetingPoints;
        }

        // GET: api/MeetingPointsData/5
        [ResponseType(typeof(MeetingPoint))]
        public IHttpActionResult GetMeetingPoint(int id)
        {
            MeetingPoint meetingPoint = db.MeetingPoints.Find(id);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meetingPoint.ID)
            {
                return BadRequest();
            }

            db.Entry(meetingPoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MeetingPointsData
        [ResponseType(typeof(MeetingPoint))]
        public IHttpActionResult PostMeetingPoint(MeetingPoint meetingPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MeetingPoints.Add(meetingPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meetingPoint.ID }, meetingPoint);
        }

        // DELETE: api/MeetingPointsData/5
        [ResponseType(typeof(MeetingPoint))]
        public IHttpActionResult DeleteMeetingPoint(int id)
        {
            MeetingPoint meetingPoint = db.MeetingPoints.Find(id);
            if (meetingPoint == null)
            {
                return NotFound();
            }

            db.MeetingPoints.Remove(meetingPoint);
            db.SaveChanges();

            return Ok(meetingPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetingPointExists(int id)
        {
            return db.MeetingPoints.Count(e => e.ID == id) > 0;
        }
    }
}
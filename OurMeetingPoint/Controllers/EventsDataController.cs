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
    public class EventsDataController : ApiController
    {
        private EventRepoEF _repo;

        public EventsDataController()
        {
            _repo = new EventRepoEF(new Context());
        }

        // GET: api/EventsData
        public IEnumerable<EventDetail> GetEvents()
        {
            return _repo.GetItems();
        }

        // GET: api/EventsData/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult GetEvent(int id)
        {
            EventDetail @event = _repo.GetItemById(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/EventsData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            EventDetail oldEvent = _repo.GetItemById(id);

            if(oldEvent == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.ID)
            {
                return BadRequest();
            }

            _repo.Update(@event);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventsData
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(@event);
            _repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = @event.ID }, @event);
        }

        // DELETE: api/EventsData/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult DeleteEvent(int id)
        {
            EventDetail @event = _repo.GetItemById(id);
            if (@event == null)
            {
                return NotFound();
            }

            _repo.Delete(id);
            _repo.Save();

            return Ok(@event);
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
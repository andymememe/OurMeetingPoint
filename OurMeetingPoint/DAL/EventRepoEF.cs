using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurMeetingPoint.Models;

namespace OurMeetingPoint.DAL
{
    public class EventRepoEF : IEventRepo
    {
        private Context _context;

        public EventRepoEF(Context context)
        {
            _context = context;
        }

        public void Create(Event item)
        {
            _context.Events.Add(item);
        }

        public void Delete(int id)
        {
            Event @event = _context.Events.Find(id);
            _context.Events.Remove(@event);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public EventDetail GetItemById(int id)
        {
            Event @event = _context.Events.Find(id);

            if(@event == null)
            {
                return null;
            }

            EventDetail eventDetail = new EventDetail()
            {
                ID = @event.ID,
                Name = @event.Name,
                Description = @event.Description,
                MeetingDate = @event.MeetingDate,
                MeetingPoint = _context.MeetingPoints.Find(@event.MeetingPointID),
                SecretCode = @event.SecretCode,
                Reviews = _context.Reviews.Where(e => e.EventID == @event.ID).ToList(),
                Reviewed = @event.Reviewed
            };

            return eventDetail;
        }

        public IEnumerable<EventDetail> GetItems()
        {
            List<EventDetail> eventDetails = new List<EventDetail>();
            List<Event> events = _context.Events.ToList();
            events.ForEach(e => eventDetails.Add(new EventDetail()
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                MeetingDate = e.MeetingDate,
                MeetingPoint = _context.MeetingPoints.Find(e.MeetingPointID),
                SecretCode = e.SecretCode,
                Reviews = _context.Reviews.Where(r => r.EventID == e.ID).ToList(),
                Reviewed = e.Reviewed
            }));

            return eventDetails;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Event item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
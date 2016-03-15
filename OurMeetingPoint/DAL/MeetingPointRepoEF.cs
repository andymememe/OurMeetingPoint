using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurMeetingPoint.Models;

namespace OurMeetingPoint.DAL
{
    public class MeetingPointRepoEF : IMeetingPointRepo
    {
        private Context _context;

        public MeetingPointRepoEF(Context context)
        {
            _context = context;
        }

        public void Create(MeetingPoint item)
        {
            item.ID = _context.MeetingPoints.Count() + 1;
            _context.MeetingPoints.Add(item);
        }

        public void Delete(int id)
        {
            MeetingPoint meetingPoint = _context.MeetingPoints.Find(id);
            _context.MeetingPoints.Remove(meetingPoint);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public MeetingPointDetail GetItemById(int id)
        {
            MeetingPoint meetingPoint = _context.MeetingPoints.Find(id);

            if(meetingPoint == null)
            {
                return null;
            }

            MeetingPointDetail meetintPointDetail = new MeetingPointDetail()
            {
                ID = meetingPoint.ID,
                Name = meetingPoint.Name,
                Description = meetingPoint.Description,
                Address = meetingPoint.Address,
                Latitude = meetingPoint.Latitude,
                Lontitude = meetingPoint.Lontitude,
                Events = _context.Events.Where(ev => ev.MeetingPointID == meetingPoint.ID).ToList()

            };

            return meetintPointDetail;
        }

        public IEnumerable<MeetingPointDetail> GetItems()
        {
            List<MeetingPointDetail> meetingPointDetails = new List<MeetingPointDetail>();
            List<MeetingPoint> meetingPoints = _context.MeetingPoints.ToList();

            meetingPoints.ForEach(e => meetingPointDetails.Add(new MeetingPointDetail() {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                Address = e.Address,
                Latitude = e.Latitude,
                Lontitude = e.Lontitude,
                Events = _context.Events.Where(ev => ev.MeetingPointID == e.ID).ToList()
            }));

            return meetingPointDetails;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MeetingPoint item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
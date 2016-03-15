using OurMeetingPoint.DAL.Http;
using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OurMeetingPoint.Controllers
{
    public class EventController : Controller
    {
        EventHttpRepo _repo;
        ReviewHttpRepo _reviewRepo;

        public EventController()
        {
            _repo = new EventHttpRepo("/api/EventsData/", "http://localhost:59381/");
            _reviewRepo = new ReviewHttpRepo("/api/ReviewsData/", "http://localhost:59381/");
        }

        [HttpPost]
        public async Task<ActionResult> View(int id, string secret)
        {
            EventDetail @event = await _repo.GetItemById(id);
            if (@event.Name == null)
            {
                return HttpNotFound("This ID is unavaliable");
            }
            if (@event.SecretCode != secret)
            {
                return new HttpUnauthorizedResult("Wrong Secret Code");
            }

            return View(@event);
        }

        [HttpGet]
        public async Task<ActionResult> Share(int id)
        {
            EventDetail @event = await _repo.GetItemById(id);
            if (@event.Name == null)
            {
                return HttpNotFound("This ID is unavaliable");
            }

            return View(@event);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> New(Event Event, string MeetingDate)
        {
            Event.MeetingDate = DateTime.ParseExact(MeetingDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            await _repo.Create(Event);
            List<EventDetail> eventDetails = await _repo.GetItems();
            EventDetail eventDetail = eventDetails.Last();

            return View("View", eventDetail);
        }

        [HttpPost]
        public async Task<ActionResult> Reviewed(Review Review)
        {
            EventDetail eventDetail = await _repo.GetItemById(Review.EventID);
            Event @event = new Event()
            {
                ID = eventDetail.ID,
                Name = eventDetail.Name,
                Description = eventDetail.Description,
                MeetingDate = eventDetail.MeetingDate,
                MeetingPointID = eventDetail.MeetingPoint.ID,
                Reviewed = true,
                SecretCode = eventDetail.SecretCode
            };

            await _repo.Update(Review.EventID, @event);
            await _reviewRepo.Create(Review);

            eventDetail = await _repo.GetItemById(Review.EventID);
            return View("View", eventDetail);
        }
    }
}
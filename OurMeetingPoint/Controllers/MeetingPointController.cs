using OurMeetingPoint.DAL.Http;
using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OurMeetingPoint.Controllers
{
    public class MeetingPointController : Controller
    {
        MeetingPointHttpRepo _repo;

        public MeetingPointController()
        {
            _repo = new MeetingPointHttpRepo("/api/MeetingPointsData/", "http://localhost:59381/");
        }

        public ActionResult New()
        {
            return View();
        }

        public async Task<ActionResult> Ok(MeetingPoint MeetingPoint)
        {
            await _repo.Create(MeetingPoint);

            List<MeetingPointDetail> meetingPointDetails = await _repo.GetItems();
            MeetingPointDetail meetingPointDetail = meetingPointDetails.LastOrDefault();
            return View(meetingPointDetail);
        }
    }
}

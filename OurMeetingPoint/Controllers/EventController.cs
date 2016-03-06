﻿using OurMeetingPoint.DAL.Http;
using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OurMeetingPoint.Controllers
{
    public class EventController : Controller
    {
        EventHttpRepo _repo;

        public EventController()
        {
            _repo = new EventHttpRepo("/api/EventsData/", "http://localhost:59381/");
        }

        [HttpPost]
        public async Task<ActionResult> View(int id, string secret)
        {
            List<EventDetail> events = await _repo.GetItems();
            EventDetail @event = await _repo.GetItemById(id);
            if(@event.Name == null)
            {
                return HttpNotFound("This ID is unavaliable");
            }
            if(@event.SecretCode != secret)
            {
                return new HttpUnauthorizedResult("Wrong Secret Code");
            }

            return View(@event);
        }
    }
}
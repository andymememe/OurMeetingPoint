using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMeetingPoint.DAL
{
    public interface IEventRepo : IRepo<Event, EventDetail>
    {
    }
}

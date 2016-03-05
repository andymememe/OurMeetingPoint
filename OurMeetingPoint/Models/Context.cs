using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OurMeetingPoint.Models
{
    public class Context : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<MeetingPoint> MeetingPoints { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public Context() : base("Connection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
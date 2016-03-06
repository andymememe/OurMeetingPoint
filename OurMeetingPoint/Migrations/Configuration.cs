namespace OurMeetingPoint.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<OurMeetingPoint.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OurMeetingPoint.Models.Context context)
        {
            List<MeetingPoint> meetingPoints = new List<MeetingPoint>()
            {
                new MeetingPoint() { ID = 1, Name = "Terminal 2, Dublin Airport", Description = "Terminal 2 of Dublin Airport.", Address = "Terminal 2, Swords, Co. Dublin", Lontitude = -6.24116, Latitude = 53.425572 },
                new MeetingPoint() { ID = 2, Name = "Terminal 1, Dublin Airport", Description = "Terminal 1 of Dublin Airport.", Address = "Terminal 1, Swords, Co. Dublin", Lontitude = -6.244289, Latitude = 53.427394 },
                new MeetingPoint() { ID = 3, Name = "Connolly Station, Dublin", Description = "A train station in Dublin.", Address = "1 Amiens St, Co. Dublin", Lontitude = -6.246538, Latitude = 53.352342 }
            };

            meetingPoints.ForEach(e => context.MeetingPoints.Add(e));
            context.SaveChanges();

            List<Event> events = new List<Event>()
            {
                new Event() { ID = 1, Name = "Test Event 1", Description = "Just for the test.", MeetingDate = DateTime.Parse("2016-03-11"), MeetingPointID = 1, Reviewed = false, SecretCode = "12345" },
                new Event() { ID = 2, Name = "Test Event 2", Description = "Just for the second test.", MeetingDate = DateTime.Parse("2016-05-08"), MeetingPointID = 2, Reviewed = true, SecretCode = "12345" }
            };

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            Review review = new Review() { ID = 1, Title = "Best meeting point ever", Description = "So good! So great!", Rate = 5, MeetingPointID = 1 };
            context.Reviews.Add(review);
            context.SaveChanges();
        }
    }
}

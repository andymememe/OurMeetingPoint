namespace OurMeetingPoint.Migrations
{
    using Hash;
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
            List<Event> events = new List<Event>()
            {
                new Event() { Name = "Test Event 1", Description = "Just for the test.", MeetingDate = DateTime.Parse("2016-03-11"), MeetingPointID = 10, Reviewed = false, SecretCode = SecretCodeGenerator.GetSecretCode(5) },
                new Event() { Name = "Test Event 2", Description = "Just for the second test.", MeetingDate = DateTime.Parse("2016-05-08"), MeetingPointID = 11, Reviewed = true, SecretCode = SecretCodeGenerator.GetSecretCode(5) }
            };

            context.SaveChanges();

            events.ForEach(e => context.Events.Add(e));

            Review review = new Review() { Title = "Best meeting point ever", Description = "So good! So great!", Rate = 5, MeetingPointID = 11 };
            context.Reviews.Add(review);

            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurMeetingPoint.Models
{
    public class MeetingPoint
    {
        // Primary Key
        [Key]
        public int ID { get; set; }

        // Data
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Lontitude { get; set; }

        // Foreign Key
        public ICollection<Event> Events { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
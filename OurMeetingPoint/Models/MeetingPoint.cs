using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OurMeetingPoint.Models
{
    public class MeetingPoint
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // Data
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }
        
        public double Latitude { get; set; }
        public double Lontitude { get; set; }

        // Foreign Key
        public ICollection<Event> Events { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

    public class MeetingPointDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Lontitude { get; set; }

        public List<Event> Events { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
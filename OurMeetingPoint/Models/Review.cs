using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OurMeetingPoint.Models
{
    public class Review
    {
        // Primary Key
        [Key]
        public int ID { get; set; }

        // Data
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }

        [Required]
        [ForeignKey("MeetingPoint")]
        public int MeetingPointID { get; set; }

        // Foreign Key
        public MeetingPoint MeetingPoint { get; set; }
    }
}
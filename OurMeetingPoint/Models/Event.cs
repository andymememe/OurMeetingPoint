using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OurMeetingPoint.Models
{
    public class Event
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // Data
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("MeetingPoint")]
        public int MeetingPointID { get; set; }

        [Required]
        public string SecretCode { get; set; }

        [Required]
        public bool Reviewed { get; set; }

        // Foreign Key
        public MeetingPoint MeetingPoint { get; set; }
    }

    public class EventDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Description { get; set; }
        public bool Reviewed { get; set; }
        public string SecretCode { get; set; }

        public MeetingPoint MeetingPoint { get; set; }
    }
}
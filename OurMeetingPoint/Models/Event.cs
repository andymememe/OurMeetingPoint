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
        [Key]
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

        // Foreign Key
        public MeetingPoint MeetingPoint { get; set; }
    }
}
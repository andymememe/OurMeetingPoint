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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey("Event")]
        public int EventID { get; set; }

        // Foreign Key
        public Event Event { get; set; }
    }

    public class ReviewDetail
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        
        public Event Event { get; set; }
    }
}
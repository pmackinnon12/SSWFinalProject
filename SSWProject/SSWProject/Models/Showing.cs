using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSWProject.Models
{
    public class Showing
    {
        [Required]
        [Key]
        public int ShowingID { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public int ListingID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Showing Date")]
        public DateTime ShowingDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
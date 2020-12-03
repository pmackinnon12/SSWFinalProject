using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSWProject.Models
{
    public class Listing
    {
        public enum HeatingTypes
        {
            Electric,
            Fireplace
        }
        private HeatingTypes typeOfHeating;

        [Required]
        [Key]
        public int ListingID { get; set; }

        [Display(Name = "Agent Name")]
        public int AgentID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "Province")]
        public Provinces Province { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Postal Code")]
        [RegularExpression(@"([A-Z]\d){3}")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Municipality")]
        public string Municipality { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Area of City")]
        public string AreaOfCity { get; set; }

        [Required]
        [Display(Name ="Number of Stories")]
        [Range(1, 100)]
        public int NumberOfStories { get; set; }

        [Required]
        [Display(Name ="Number of Beds")]
        [Range(1, 100)]
        public int NumberOfBeds { get; set; }

        [Required]
        [Display(Name ="Number of Baths")]
        [Range(1, 100)]
        public int NumberOfBaths { get; set; }

        [Required]
        [Display(Name = "Summay")]
        public string Summary { get; set; }

        [Required]
        [Display(Name = "Type of Heating")]
        public HeatingTypes TypeOfHeating { get; set; }

        [Required]
        [Range(1000, 10000000000)]
        [Display(Name ="Sales Price")]
        public decimal SalesPrice { get; set; }

        [Required]
        [Display(Name ="Contract Signed")]
        public bool IsContractSigned { get; set; }

        public virtual ICollection<ListingFile> Files { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SSWProject.Models.Agent;

namespace SSWProject.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Customer First Name")]
        public string FirstName { get; set; }

        [StringLength(25)]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Customer Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Municipality")]
        public string Municipality { get; set; }

        [Required]
        [Display(Name = "Province")]
        public Provinces Province { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name ="Postal Code")]
        [RegularExpression(@"([A-Z]\d){3}")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Home Phone is required. Must be a valid phone number")]
        [StringLength(15)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [StringLength(15)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        public virtual ICollection<CustomerFile> Files { get; set; }
    }
}
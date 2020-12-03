using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSWProject.Models
{
    public enum Provinces
    {
        ON,
        QC,
        NB,
        NS,
        PEI,
        NF,
        MA,
        BC,
        AL,
        SK,
        NWT,
        YU,
        NU
    }
    public class Agent
    {
        
        private Provinces province;
         
        [Required]
        [Key]
        public int AgentID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(25)]
        [Display(Name ="Agent First Name")]
        public string FirstName { get; set; }

        [StringLength(25)]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(25)]
        [Display(Name ="Agent Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(25)]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Job Role")]
        public string JobRole { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Municipality")]
        public string Municipality { get; set; }

        [Required]
        [Display(Name ="Province")]
        public Provinces Province { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name ="Postal Code")]
        [RegularExpression(@"([A - Z]\d){3}")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Home Phone is required. Must be a valid phone number")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$")]
        [Display(Name ="Home Phone")]
        public string HomePhone { get; set; }

        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$")]
        [Display(Name ="Cell Phone")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "Office Email is required. Must be a valid email address")]
        [StringLength(50)]
        [Display(Name ="Office Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string OfficeEmail { get; set; }

        [Required(ErrorMessage = "Office Phone is required. Must be a valid phone number")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Office Phone")]
        [RegularExpression(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$")]
        public string OfficePhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name ="Social Insurance Number")]
        public int SIN { get; set; }

        public virtual ICollection<AgentFile> files { get; set; }
    }
}
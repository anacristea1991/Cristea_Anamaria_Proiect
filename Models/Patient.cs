using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cristea_Anamaria_Proiect.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Display(Name = "CNP")]
        [Required]
        public string CNP { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public Gender Gender { get; set; }
        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "BirthDate")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Display(Name = "City")]
        [Required]
        public City City { get; set; }
        [Display(Name = "Street")]
        [Required]
        public string Street { get; set; }
        [Display(Name = "Street Number")]
        [Required]
        public string StreetNumber { get; set; }
        [Display(Name = "Assigned Doctor")]
        [Required]
        public MedicalStaff AssignedDoctor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cristea_Anamaria_Proiect.Models
{
    public class MedicalStaff
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "The {0} is required. Value format hh:mm")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "The {0} is required. Value format hh:mm")]
        public TimeSpan EndTime { get; set; }
        [Display(Name = "Specialisation")]
        public Specialisation Specialisation { get; set; }
        [Display(Name = "ConsultationRoom")]
        public Room ConsultationRoom { get; set; }
        [NotMapped]
        public int ConsultationRoomId { set; get; }
    }
}

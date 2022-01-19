using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cristea_Anamaria_Proiect.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient{get;set;}
        public MedicalStaff MedicalStaff { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        [NotMapped]
        public int PatientId { get; set; }
        [NotMapped]
        public int MedicalStaffId { get; set; }
    }
}

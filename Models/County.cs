using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cristea_Anamaria_Proiect.Models
{
    public class County
    {
        [Display(Name="County Code")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "The County Code value cannot exceed 2 characters. ")]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

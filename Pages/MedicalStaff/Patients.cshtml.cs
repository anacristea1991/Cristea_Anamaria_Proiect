using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cristea_Anamaria_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cristea_Anamaria_Proiect.Pages.MedicalStaff
{
    public class PatientsModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;
        public PatientsModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }
        public List<Patient> Patients { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patients = await _context.Patient.Include(p=>p.AssignedDoctor).Where(p=>p.AssignedDoctor.Id==id).ToListAsync();

            return Page();
        }
    }
}

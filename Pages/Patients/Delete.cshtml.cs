using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public DeleteModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.Include(p => p.AssignedDoctor)
                .Include(p => p.City).ThenInclude(c => c.County).FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.Include(p => p.AssignedDoctor)
                .Include(p => p.City).ThenInclude(c => c.County).FirstOrDefaultAsync(m => m.Id == id); ;

            if (Patient != null)
            {
                if (_context.Appointment.Include(c => c.Patient).Any(c => c.Patient.Id == id))
                {
                    ViewData["DeleteError"] = "You cannot delete a patient assigned to an appointment. Update the appointment for this patient and then try again.";
                    return Page();
                }
                _context.Patient.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

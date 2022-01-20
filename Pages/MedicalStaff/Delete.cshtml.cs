using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.MedicalStaff
{
    public class DeleteModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public DeleteModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.MedicalStaff MedicalStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalStaff = await _context.MedicalStaff.Include(m=>m.ConsultationRoom).FirstOrDefaultAsync(m => m.Id == id);

            if (MedicalStaff == null)
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

            MedicalStaff = await _context.MedicalStaff.Include(m => m.ConsultationRoom).FirstOrDefaultAsync(m => m.Id == id); ;

            if (MedicalStaff != null)
            {
                if (_context.Patient.Include(c => c.AssignedDoctor).Any(c => c.AssignedDoctor.Id == id))
                {
                    ViewData["DeleteError"] = "You cannot delete a doctor assigned to a pacient. Update the patients for this doctor and then try again.";
                    return Page();
                }
                if (_context.Appointment.Include(c => c.MedicalStaff).Any(c => c.MedicalStaff.Id == id))
                {
                    ViewData["DeleteError"] = "You cannot delete a doctor assigned to an appointment. Update the appointment for this doctor and then try again.";
                    return Page();
                }
                _context.MedicalStaff.Remove(MedicalStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

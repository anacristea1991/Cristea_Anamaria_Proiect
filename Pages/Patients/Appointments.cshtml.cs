using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cristea_Anamaria_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cristea_Anamaria_Proiect.Pages.Patients
{
    public class AppointmentsModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;
        public AppointmentsModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }
        public List<Appointment> Appointments { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointments = await _context.Appointment.Include(p => p.MedicalStaff)
                .Include(p=>p.Patient)
                .Where(p => p.Patient.Id == id).ToListAsync();

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public IndexModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment.Include(a=>a.MedicalStaff).Include(a=>a.Patient).ToListAsync();
        }
    }
}

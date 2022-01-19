using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public EditModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
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

            Patient = await _context.Patient.Include(p => p.City).Include(p => p.AssignedDoctor).FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            ViewData["Genders"] = GetGenders();
            ViewData["Cities"] = GetCities();
            ViewData["Doctors"] = GetDoctors();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Genders"] = GetGenders();
                ViewData["Cities"] = GetCities();
                ViewData["Doctors"] = GetDoctors();
                return Page();
            }

            _context.Attach(Patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
        private SelectList GetGenders()
        {
            var genders = from Gender g in Enum.GetValues(typeof(Gender))
                          select new { ID = (int)g, Name = g.ToString() };
            return new SelectList(genders, "ID", "Name");
        }
        private SelectList GetCities()
        {
            var counties = from City c in _context.City.Include(m => m.County).ToList()
                           select new { ID = c.Id, Name = string.Format("{0}-{1}", c.County.Id, c.Name) };
            return new SelectList(counties, "ID", "Name");
        }
        private SelectList GetDoctors()
        {
            var doctors = from Models.MedicalStaff m
                        in _context.MedicalStaff.Where(r => r.Specialisation == Specialisation.Doctor).ToList()
                          select new { ID = (int)m.Id, Name = string.Format("{0} {1}", m.FirstName, m.LastName) };
            return new SelectList(doctors, "ID", "Name");
        }
    }
}

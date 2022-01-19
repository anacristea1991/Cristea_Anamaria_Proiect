using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Cristea_Anamaria_Proiect.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public CreateModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Genders"] = GetGenders();
            ViewData["Cities"] = GetCities();
            ViewData["Doctors"] = GetDoctors();
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Patient.City.Name");
            ModelState.Remove("Patient.AssignedDoctor.FirstName");
            ModelState.Remove("Patient.AssignedDoctor.LastName");
            if (!ModelState.IsValid)
            {
                ViewData["Genders"] = GetGenders();
                ViewData["Cities"] = GetCities();
                ViewData["Doctors"] = GetDoctors();
                return Page();
            }
            Patient.City = _context.City.First(c => c.Id == Patient.City.Id);
            Patient.AssignedDoctor = _context.MedicalStaff.First(m => m.Id == Patient.AssignedDoctor.Id);
            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
                           select new { ID = c.Id, Name = string.Format("{0}-{1}",c.County.Id, c.Name) };
            return new SelectList(counties, "ID", "Name");
        }
        private SelectList GetDoctors()
        {
            var doctors = from Models.MedicalStaff m 
                        in _context.MedicalStaff.Where(r => r.Specialisation==Specialisation.Doctor).ToList()
                        select new { ID = (int)m.Id, Name = string.Format("{0} {1}", m.FirstName, m.LastName) };
            return new SelectList(doctors, "ID", "Name");
        }
    }
}

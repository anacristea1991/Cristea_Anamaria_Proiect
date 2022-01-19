using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Appointments
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
            ViewData["MedicalStaff"] = GetMedicalStaff();
            ViewData["Patients"] = GetPatients();
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MedicalStaff"] = GetMedicalStaff();
                ViewData["Patients"] = GetPatients();
                return Page();
            }
            Appointment.MedicalStaff = _context.MedicalStaff.FirstOrDefault(m => m.Id == Appointment.MedicalStaffId);
            var time = Appointment.Date.ToString("HH:mm");
            var timeSplit = time.Split(':');
            var appSpan = new TimeSpan(int.Parse(timeSplit[0]), int.Parse(timeSplit[1]), 0);
            if (appSpan < Appointment.MedicalStaff.StartTime || appSpan > Appointment.MedicalStaff.EndTime)
            {
                ModelState.AddModelError("Appointment.Date", "This is not a valid time for appointment.");
                ViewData["MedicalStaff"] = GetMedicalStaff();
                ViewData["Patients"] = GetPatients();
                return Page();
            }
            Appointment.Patient=_context.Patient.FirstOrDefault(m => m.Id == Appointment.PatientId);
            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private SelectList GetMedicalStaff()
        {
            var doctors = from Models.MedicalStaff m
                        in _context.MedicalStaff.ToList()
                          select new
                          {
                              ID = (int)m.Id,
                              Name = string.Format("{0}-{1} {2} {3}-{4}", m.Specialisation, m.FirstName, m.LastName, m.StartTime, m.EndTime)
                          };
            return new SelectList(doctors, "ID", "Name");
        }
        private SelectList GetPatients()
        {
            var patients = from Patient m
                        in _context.Patient.ToList()
                           select new
                           {
                               ID = (int)m.Id,
                               Name = string.Format("{0} {1}", m.FirstName, m.LastName)
                           };
            return new SelectList(patients, "ID", "Name");
        }
    }
}

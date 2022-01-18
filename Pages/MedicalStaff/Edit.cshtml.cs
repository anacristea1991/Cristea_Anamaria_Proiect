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

namespace Cristea_Anamaria_Proiect.Pages.MedicalStaff
{
    public class EditModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public EditModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
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
            ViewData["Specialisations"] = GetSpecialisations();
            ViewData["Rooms"] = GetRooms();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Specialisations"] = GetSpecialisations();
                ViewData["Rooms"] = GetRooms();
                return Page();
            }

            _context.Attach(MedicalStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalStaffExists(MedicalStaff.Id))
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

        private bool MedicalStaffExists(int id)
        {
            return _context.MedicalStaff.Any(e => e.Id == id);
        }
        private SelectList GetSpecialisations()
        {
            var specialisations = from Specialisation s in Enum.GetValues(typeof(Specialisation))
                                  select new { ID = (int)s, Name = s.ToString() };
            return new SelectList(specialisations, "ID", "Name");
        }
        private SelectList GetRooms()
        {
            var rooms = from Room r in _context.Room.Where(r => r.IsAvailable).ToList()
                        select new { ID = (int)r.Id, Name = string.Format("{0}.{1}", r.Floor, r.RoomNumber) };
            return new SelectList(rooms, "ID", "Name");
        }
    }
}

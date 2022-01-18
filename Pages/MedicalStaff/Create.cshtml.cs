using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.MedicalStaff
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
            ViewData["Specialisations"] = GetSpecialisations();
            ViewData["Rooms"] = GetRooms();
            return Page();
        }

        [BindProperty]
        public Models.MedicalStaff MedicalStaff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("MedicalStaff.ConsultationRoom.Floor");
            ModelState.Remove("MedicalStaff.ConsultationRoom.RoomNumber");
            if (!ModelState.IsValid)
            {
                ViewData["Specialisations"] = GetSpecialisations();
                ViewData["Rooms"] = GetRooms();
                return Page();
            }
            MedicalStaff.ConsultationRoom = _context.Room.First(r => r.Id == MedicalStaff.ConsultationRoom.Id);
            _context.MedicalStaff.Add(MedicalStaff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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

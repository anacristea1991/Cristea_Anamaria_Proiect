using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Counties
{
    public class DeleteModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public DeleteModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public County County { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            County = await _context.County.FirstOrDefaultAsync(m => m.Id == id);

            if (County == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            County = await _context.County.FindAsync(id);

            if (County != null)
            {
                if (_context.City.Include(c => c.County).Any(c => c.County.Id == id))
                {
                    ViewData["DeleteError"] = "You cannot delete a county used by a city. Update the cities for this county and then try again.";
                    return Page();
                }
                _context.County.Remove(County);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

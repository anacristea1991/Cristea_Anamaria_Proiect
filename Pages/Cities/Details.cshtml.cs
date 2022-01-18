using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext _context;

        public DetailsModel(Cristea_Anamaria_Proiect.Data.Cristea_Anamaria_ProiectContext context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.Include(c=>c.County).FirstOrDefaultAsync(m => m.Id == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

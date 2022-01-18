using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cristea_Anamaria_Proiect.Data;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Pages.Cities
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
            ViewData["Counties"] = GetCounties();
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("City.County.Name");
            if (!ModelState.IsValid)
            {
                ViewData["Counties"] = GetCounties();
                return Page();
            }
            City.County = _context.County.First(c => c.Id == City.County.Id);
            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private SelectList GetCounties()
        {
            var counties= from County c in _context.County.ToList()
                          select new { ID = c.Id, Name = string.Format("{0}-{1}", c.Id, c.Name) };
            return new SelectList(counties, "ID", "Name");
        }
    }
}

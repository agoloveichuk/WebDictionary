using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Infrastructure.Data;

namespace WebDictionary.Pages.ff
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionaryContext _context;

        public CreateModel(WebDictionaryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Dictionary == null || Dictionary == null)
            {
                return Page();
            }

            _context.Dictionary.Add(Dictionary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

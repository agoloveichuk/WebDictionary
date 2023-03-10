using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;

namespace WebDictionary.Pages.ff
{
    public class EditModel : PageModel
    {
        private readonly Infrastructure.Data.WebDictionaryContext _context;

        public EditModel(Infrastructure.Data.WebDictionaryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary =  await _context.Dictionary.FirstOrDefaultAsync(m => m.DictionaryId == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            Dictionary = dictionary;
           ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dictionary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryExists(Dictionary.DictionaryId))
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

        private bool DictionaryExists(int id)
        {
          return (_context.Dictionary?.Any(e => e.DictionaryId == id)).GetValueOrDefault();
        }
    }
}

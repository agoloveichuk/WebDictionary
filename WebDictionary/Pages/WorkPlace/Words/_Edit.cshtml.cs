using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class EditModel : PageModel
    {
        private readonly WebDictionary.Data.WebDictionaryContext context;

        public EditModel(WebDictionary.Data.WebDictionaryContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Word Word { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Word == null)
            {
                return NotFound();
            }

            var word =  await context.Word.FirstOrDefaultAsync(m => m.WordId == id);
            if (word == null)
            {
                return NotFound();
            }
            Word = word;
           ViewData["DictionaryId"] = new SelectList(context.Dictionary, "DictionaryId", "Description");
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

            context.Attach(Word).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(Word.WordId))
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

        private bool WordExists(int id)
        {
          return (context.Word?.Any(e => e.WordId == id)).GetValueOrDefault();
        }
    }
}

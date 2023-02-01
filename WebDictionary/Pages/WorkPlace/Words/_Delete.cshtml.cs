using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class DeleteModel : PageModel
    {
        private readonly WebDictionary.Data.WebDictionaryContext context;

        public DeleteModel(WebDictionary.Data.WebDictionaryContext context)
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

            var word = await context.Word.FirstOrDefaultAsync(m => m.WordId == id);

            if (word == null)
            {
                return NotFound();
            }
            else 
            {
                Word = word;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Word == null)
            {
                return NotFound();
            }
            var word = await context.Word.FindAsync(id);

            if (word != null)
            {
                Word = word;
                context.Word.Remove(Word);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

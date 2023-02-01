using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionary.Data.WebDictionaryContext context;

        public CreateModel(WebDictionary.Data.WebDictionaryContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DictionaryId"] = new SelectList(context.Dictionary, "DictionaryId", "Description");
            return Page();
        }

        [BindProperty]
        public Word Word { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || context.Word == null || Word == null)
            {
                return Page();
            }

            context.Word.Add(Word);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

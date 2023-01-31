using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionaryContext context;

        public CreateModel(WebDictionaryContext context) => this.context = context;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || context.Dictionary == null || Dictionary == null)
            {
                return Page();
            }

            context.Dictionary.Add(Dictionary);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class DetailsModel : PageModel
    {
        private readonly WebDictionaryContext context;

        public DetailsModel(WebDictionaryContext context) => this.context = context;
        public Dictionary Dictionary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await context.Dictionary.FirstOrDefaultAsync(m => m.DictionaryId == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            else
            {
                Dictionary = dictionary;
            }
            return Page();
        }
    }
}

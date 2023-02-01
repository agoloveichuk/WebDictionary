using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class DetailsModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public DetailsModel(WebDictionaryContext context) => this.context = context;

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
    }
}

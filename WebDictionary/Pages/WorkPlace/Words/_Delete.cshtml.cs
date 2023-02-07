using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class DeleteModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public DeleteModel(WebDictionaryContext context) => this.context = context;

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
                unitOfWork.WordRepository.Delete(Word);
                await unitOfWork.SaveAsync();
            }

            return RedirectToPage("/WorkPlace/WorkPlace");
        }
    }
}

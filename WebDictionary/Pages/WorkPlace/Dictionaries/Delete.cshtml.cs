using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class DeleteModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public DeleteModel(WebDictionaryContext context) => this.context = context;

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Dictionary == null)
            {
                return NotFound();
            }
            var dictionary = await context.Dictionary.FindAsync(id);

            if (dictionary != null)
            {
                Dictionary = dictionary;
                //context.Dictionary.Remove(Dictionary);
                unitOfWork.DictionaryRepository.Delete(Dictionary.DictionaryId);
                await unitOfWork.SaveAsync();
            }

            return RedirectToPage("/WorkPlace/WorkPlace");
        }
    }
}

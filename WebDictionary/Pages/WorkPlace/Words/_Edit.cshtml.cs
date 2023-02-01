using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class EditModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public EditModel(WebDictionaryContext context) => this.context = context;

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
            Word = word;
            ViewData["DictionaryId"] = new SelectList(context.Dictionary, "DictionaryId", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            unitOfWork.WordRepository.Update(Word);

            try
            {
                await unitOfWork.SaveAsync();
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

            return RedirectToPage("/WorkPlace/WorkPlace");
        }

        private bool WordExists(int id)
        {
            return (context.Word?.Any(e => e.WordId == id)).GetValueOrDefault();
        }
    }
}

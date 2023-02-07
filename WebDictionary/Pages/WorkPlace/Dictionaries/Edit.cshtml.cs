using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class EditModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public EditModel(WebDictionaryContext context) => this.context = context;

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
            Dictionary = dictionary;
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

            unitOfWork.DictionaryRepository.Update(Dictionary);

            try
            {
                await unitOfWork.SaveAsync();
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

            return RedirectToPage("/WorkPlace/WorkPlace");
        }

        private bool DictionaryExists(int id)
        {
            return (context.Dictionary?.Any(e => e.DictionaryId == id)).GetValueOrDefault();
        }
    }
}

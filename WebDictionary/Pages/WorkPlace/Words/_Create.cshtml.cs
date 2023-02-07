using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Data;

namespace WebDictionary.Pages.WorkPlace.Words
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        public CreateModel(WebDictionaryContext context) => this.context = context;

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
            //if (!ModelState.IsValid || context.Word == null || Word == null)
            //{
            //    return Page();
            //}

            unitOfWork.WordRepository.Create(Word);
            await unitOfWork.SaveAsync();

            return RedirectToPage("/WorkPlace/WorkPlace");
        }
    }
}

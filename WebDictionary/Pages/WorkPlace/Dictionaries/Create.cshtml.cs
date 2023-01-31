using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();
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
            //if (!ModelState.IsValid || context.Dictionary == null || Dictionary == null)
            //{
            //    return Page();
            //}

            unitOfWork.DictionaryRepository.Create(Dictionary);
            //context.Dictionary.Add(Dictionary);
            await unitOfWork.SaveAsync();

            return RedirectToPage("/WorkPlace/WorkPlace");
        }
    }
}

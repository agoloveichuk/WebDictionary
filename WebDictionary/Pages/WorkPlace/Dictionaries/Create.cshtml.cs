using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDictionary.Pages.WorkPlace
{
    public class CreateModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();

        //private readonly SignInManager<AppUser> signInManager;
        //private readonly UserManager<AppUser> userManager;
        public CreateModel(WebDictionaryContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AppUserId"] = new SelectList(context.AppUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;

        //[CascadingParameter]
        //private Task<AuthenticationState> authenticationStateTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || context.Dictionary == null || Dictionary == null)
            //{
            //    return Page();
            //}
            //var authState = await authenticationStateTask;
            //var user = authState.User;
            //Dictionary.AppUserId = userManager.GetUserId(user);
            unitOfWork.DictionaryRepository.Create(Dictionary);
            //context.Dictionary.Add(Dictionary);
            await unitOfWork.SaveAsync();

            return RedirectToPage("/WorkPlace/WorkPlace");
        }
    }
}

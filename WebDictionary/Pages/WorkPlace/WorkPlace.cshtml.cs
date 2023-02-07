using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();
        private readonly IWordRepository wordRepository;

        public IndexModel(WebDictionaryContext context, IWordRepository wordRepository)
            => (this.context, this.wordRepository) = (context, wordRepository);

        public IList<Word> Words { get; set; } = default!;
        public IList<Dictionary>? Dictionaries { get; set; } = default!;
        //public AppUser user { get; set; }
        //[CascadingParameter]
        //private Task<AuthenticationState> authenticationStateTask { get; set; }

        public async Task OnGetAsync(int id = 1)
        {
            //Dictionaries = user.Dictionaries;
            Words = (IList<Word>)await wordRepository.GetAllByDictionaryIdAsync(id);
            //var authState = await authenticationStateTask;
            //var user = authState.User;
            //if (user.Identity.IsAuthenticated && user != null)
            //{
            //    AppUser = Infrastructure.Data.Entities.AppUser.Dictionaries Where(x.Name => x.user.Identity.Name);
            //}
            //else
            //{
            //    Console.WriteLine("The user is NOT authenticated.");
            //}
            Dictionaries = (IList<Dictionary>)await unitOfWork.DictionaryRepository.GetAllAsync();
            //Words = (IList<Word>)await wordRepository.GetAllByDictionaryIdAsync(id);
        }
    }
}

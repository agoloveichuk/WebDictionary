using Domain.Entities;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly IGenericRepository<Dictionary> dictionaryRepository;

        public IndexModel(WebDictionaryContext context, IGenericRepository<Dictionary> dictionaryRepository) 
            => (this.context, this.dictionaryRepository) = (context, dictionaryRepository);

        public IList<Dictionary> Dictionary { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (context.Dictionary != null)
            {
                Dictionary = (IList<Dictionary>) await dictionaryRepository.GetAllAsync();
            }
        }
    }
}

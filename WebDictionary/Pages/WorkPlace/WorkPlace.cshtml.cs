using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private readonly UnitOfWork unitOfWork = new();
        private readonly IWordRepository wordRepository;

        public IndexModel(WebDictionaryContext context, IWordRepository wordRepository) 
            => (this.context, this.wordRepository) = (context, wordRepository);

        public IList<Word> Word { get; set; } = default!;
        public IList<Dictionary> Dictionary { get; set; } = default!;
        public async Task OnGetAsync(int id = 1)
        {
            if (context.Dictionary != null)
            {
                Dictionary = (IList<Dictionary>) await unitOfWork.DictionaryRepository.GetAllAsync();
            }
            Word = (IList<Word>)await wordRepository.GetAllByDictionaryIdAsync(id);
        }
    }
}

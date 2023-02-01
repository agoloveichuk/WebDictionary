using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionaryContext context;
        private UnitOfWork unitOfWork = new();

        public IndexModel(WebDictionaryContext context) => (this.context) = (context);

        public IList<Word> Words { get; set; } = default!;
        public IList<Dictionary> Dictionary { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (context.Dictionary != null)
            {
                Dictionary = (IList<Dictionary>) await unitOfWork.DictionaryRepository.GetAllAsync();
            }
            if(context.Word != null)
            {
                Words = (IList<Word>) await unitOfWork.WordRepository.GetAllAsync();
            }
        }
    }
}

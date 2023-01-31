using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionaryContext context;
        //private readonly IGenericRepository<Dictionary> dictionaryRepository;
        private UnitOfWork unitOfWork = new();

        public IndexModel(WebDictionaryContext context) => (this.context) = (context);

        public IList<Dictionary> Dictionary { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (context.Dictionary != null)
            {
                Dictionary = (IList<Dictionary>) await unitOfWork.DictionaryRepository.GetAllAsync();
            }
        }
    }
}

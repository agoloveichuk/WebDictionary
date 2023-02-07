using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories
{
    public class WordRepository : GenericRepository<Word>, IWordRepository
    {
        public WordRepository(WebDictionaryContext context) : base(context)
        {

        }
        //TODO 
        // GET WORDS BY DICTIONARY ID 
        public async Task<IEnumerable<Word>> GetAllByDictionaryIdAsync(int dictionaryId)
        {
            return await context.Word.Where(x => x.DictionaryId == dictionaryId).ToListAsync();
        }
    }
}

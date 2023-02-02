using Domain.Entities;
using WebDictionary.Data;

namespace Infrastructure.Data.Repositories
{
    public class DictionaryRepository : GenericRepository<Dictionary>
    {
        public DictionaryRepository(WebDictionaryContext context) : base(context)
        {

        }
    }
}

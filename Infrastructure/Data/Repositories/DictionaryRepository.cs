using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories
{
    public class DictionaryRepository : GenericRepository<Dictionary>
    {
        public DictionaryRepository(WebDictionaryContext context) : base(context)
        {

        }
    }
}

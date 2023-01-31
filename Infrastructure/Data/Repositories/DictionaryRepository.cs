using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

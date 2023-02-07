using Domain.Entities;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories
{
    public class AccountRepository : GenericRepository<AppUser>
    {
        public AccountRepository(WebDictionaryContext context) : base(context)
        {

        }

        //public async Task<IEnumerable<Dictionary>> GetAllDictionaries()
        //{
        //    return await context.AppUser.Dictionaries
        //}
    }
}

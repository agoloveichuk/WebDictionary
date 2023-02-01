using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDictionary.Data;

namespace Infrastructure.Data
{
    public class WebDictionaryContextFactory : IDesignTimeDbContextFactory<WebDictionaryContext>
    {
        public WebDictionaryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebDictionaryContext>();
            optionsBuilder.UseSqlServer();

            return new WebDictionaryContext(optionsBuilder.Options);
        }
    }
}

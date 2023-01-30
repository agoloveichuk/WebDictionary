using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class IndexModel : PageModel
    {
        private readonly WebDictionary.Data.WebDictionaryContext _context;

        public IndexModel(WebDictionary.Data.WebDictionaryContext context)
        {
            _context = context;
        }

        public IList<Dictionary> Dictionary { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dictionary != null)
            {
                Dictionary = await _context.Dictionary.ToListAsync();
            }
        }
    }
}

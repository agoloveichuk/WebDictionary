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
    public class DetailsModel : PageModel
    {
        private readonly WebDictionary.Data.WebDictionaryContext _context;

        public DetailsModel(WebDictionary.Data.WebDictionaryContext context)
        {
            _context = context;
        }

      public Dictionary Dictionary { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary.FirstOrDefaultAsync(m => m.DictionaryId == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            else 
            {
                Dictionary = dictionary;
            }
            return Page();
        }
    }
}

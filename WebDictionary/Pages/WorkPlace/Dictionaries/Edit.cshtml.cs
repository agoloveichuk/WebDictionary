﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using WebDictionary.Data;

namespace WebDictionary.Pages.WorkPlace
{
    public class EditModel : PageModel
    {
        private readonly WebDictionaryContext context;

        public EditModel(WebDictionaryContext context) => this.context = context;

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary =  await context.Dictionary.FirstOrDefaultAsync(m => m.DictionaryId == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            Dictionary = dictionary;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(Dictionary).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryExists(Dictionary.DictionaryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DictionaryExists(int id)
        {
          return (context.Dictionary?.Any(e => e.DictionaryId == id)).GetValueOrDefault();
        }
    }
}
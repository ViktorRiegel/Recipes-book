using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;
using RecipesBook.Data;

namespace RecipesBook.Pages.Recipies
{
    public class EditModel : PageModel
    {
        private readonly RecipesBook.Data.RecipesBookContext _context;

        public EditModel(RecipesBook.Data.RecipesBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeBook RecipeBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RecipeBook == null)
            {
                return NotFound();
            }

            var recipebook =  await _context.RecipeBook.FirstOrDefaultAsync(m => m.Id == id);
            if (recipebook == null)
            {
                return NotFound();
            }
            RecipeBook = recipebook;
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

            _context.Attach(RecipeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeBookExists(RecipeBook.Id))
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

        private bool RecipeBookExists(int id)
        {
          return (_context.RecipeBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

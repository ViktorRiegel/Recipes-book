using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;
using RecipesBook.Data;

namespace RecipesBook.Pages.Recipies
{
    public class DeleteModel : PageModel
    {
        private readonly RecipesBook.Data.RecipesBookContext _context;

        public DeleteModel(RecipesBook.Data.RecipesBookContext context)
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

            var recipebook = await _context.RecipeBook.FirstOrDefaultAsync(m => m.Id == id);

            if (recipebook == null)
            {
                return NotFound();
            }
            else 
            {
                RecipeBook = recipebook;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RecipeBook == null)
            {
                return NotFound();
            }
            var recipebook = await _context.RecipeBook.FindAsync(id);

            if (recipebook != null)
            {
                RecipeBook = recipebook;
                _context.RecipeBook.Remove(RecipeBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly RecipesBookContext _context;

        public DetailsModel(RecipesBookContext context)
        {
            _context = context;
        }

        public RecipeBook RecipeBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeBook = await _context.RecipeBook.FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeBook == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

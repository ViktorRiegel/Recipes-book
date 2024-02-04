using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;

namespace Recipes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RecipesBook.Data.RecipesBookContext _context;

        public IndexModel(RecipesBook.Data.RecipesBookContext context)
        {
            _context = context;
        }

        public IList<RecipeBook> RecipeBook { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RecipeBook != null)
            {
                RecipeBook = await _context.RecipeBook.ToListAsync();
            }
        }
    }
}
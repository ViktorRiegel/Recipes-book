using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;

namespace RecipesBook.Data
{
    public class RecipesBookContext : DbContext
    {
        public RecipesBookContext (DbContextOptions<RecipesBookContext> options)
            : base(options)
        {
        }

        public DbSet<Recipes.Models.RecipeBook> RecipeBook { get; set; } = default!;
    }
}

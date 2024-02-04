using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Recipes.Models;
using RecipesBook.Data;
using Microsoft.Extensions.Configuration;
using RecipesBook.Models;

namespace RecipesBook.Pages.Recipies
{
    public class IndexModel : PageModel
    {
        private readonly RecipesBook.Data.RecipesBookContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(RecipesBook.Data.RecipesBookContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<RecipeBook> RecipeBook { get; set; } = default!;

        //Sort parameters
        public string TitleSort { get; set; }
        public string CategorySort { get; set; }
        public string ComplexitySort { get; set; }
        public string PrepTimeSort { get; set; }
        public string DateSort { get; set; }

        public string IngredientsSort { get; set; }

        public string StepsSort { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public string CurrentSort { get; set; }



        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            SearchString = searchString;
            //Sort functionality
            TitleSort = sortOrder == "titleAsc" ? "titleDesc" : sortOrder == "titleDesc" ? "" : "titleAsc";
            CategorySort = sortOrder == "categoryAsc" ? "categoryDesc" : sortOrder == "categoryDesc" ? "" : "categoryAsc";
            ComplexitySort = sortOrder == "complexityAsc" ? "complexityDesc" : sortOrder == "complexityDesc" ? "" : "complexityAsc";
            PrepTimeSort = sortOrder == "prepAsc" ? "prepDesc" : sortOrder == "prepDesc" ? "" : "prepAsc";
            DateSort = sortOrder == "dateAsc" ? "dateDesc" : sortOrder == "dateDesc" ? "" : "dateAsc";
            IngredientsSort = sortOrder == "IngredientsAsc" ? "IngredientsDesc" : sortOrder == "IngredientsDesc" ? "" : "IngredientsAsc";
            StepsSort = sortOrder == "StepsAsc" ? "StepsDesc" : sortOrder == "StepsDesc" ? "" : "StepsAsc";

            if (_context.RecipeBook != null)
            {
                var recipeBooks = from r in _context.RecipeBook select r;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    recipeBooks = recipeBooks.Where(s => s.Title.Contains(SearchString));
                }
                //Sorting
                if (!string.IsNullOrEmpty(sortOrder))
                {
                    switch (sortOrder)
                    {
                        case "titleAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.Title);
                            break;
                        case "titleDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.Title);
                            break;
                        case "categoryAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.Category);
                            break;
                        case "categoryDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.Category);
                            break;
                        case "complexityAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.Complexity);
                            break;
                        case "complexityDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.Complexity);
                            break;
                        case "prepAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.PreparationTime);
                            break;
                        case "prepDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.PreparationTime);
                            break;
                        case "dateAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.CreatedDate);
                            break;
                        case "dateDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.CreatedDate);
                            break;
                        case "IngredientsAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.Ingredients);
                            break;
                        case "IngredientsDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.Ingredients);
                            break;
                        case "StepsAsc":
                            recipeBooks = recipeBooks.OrderBy(s => s.Steps);
                            break;
                        case "StepsDesc":
                            recipeBooks = recipeBooks.OrderByDescending(s => s.Steps);
                            break;
                        default: break;
                    }
                }

                //RecipeBook = await recipeBooks.ToListAsync();
                var pageSize = Configuration.GetValue("PageSize", 4);
                RecipeBook = await PaginatedList<RecipeBook>.CreateAsync(
                    recipeBooks.AsNoTracking(), pageIndex ?? 1, pageSize);

                //RecipeBook = await _context.RecipeBook.ToListAsync();
            }
        }


    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipes.Models;
using RecipesBook.Data;
using System.IO;

namespace RecipesBook.Pages.Recipies
{
    public class CreateModel : PageModel
    {
        private readonly RecipesBook.Data.RecipesBookContext _context;

        public CreateModel(RecipesBook.Data.RecipesBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeBook RecipeBook { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RecipeBook == null || RecipeBook == null)
            {
                return Page();
            }

            _context.RecipeBook.Add(RecipeBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            return  ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
            
           

 
    }
}

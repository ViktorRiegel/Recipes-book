using System.ComponentModel.DataAnnotations;

namespace Recipes.Models;

public class RecipeBook
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    public string Complexity { get; set; }
    public double PreparationTime { get; set; }

    public string Images { get; set; }

    public string Ingredients { get; set; }

    public string Steps { get; set; }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }

    public virtual ApplicationUser User { get; set; }

    [Display(Name = "Task Completed")]


    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public int Rating { get; set; }
    public string Instructions { get; set; }
    public virtual ICollection<CategoryRecipe> JoinEntities { get; set; }

    public string StarRating()
    {
      string starRating = "";
      if (Rating > 0)
      {
        for (int i = 1; i <= Rating; i++)
        {
          starRating += "⭐ ";
        }
      }
      return starRating;
    }
  }
}
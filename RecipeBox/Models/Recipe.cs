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
  }
}
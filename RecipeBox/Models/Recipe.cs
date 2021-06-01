using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<IngredientRecipe>();
    }

    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public int Rating { get; set; }
    public string Instructions { get; set; }
    public virtual ICollection<IngredientRecipe> JoinEntities { get; set; }
  }
}
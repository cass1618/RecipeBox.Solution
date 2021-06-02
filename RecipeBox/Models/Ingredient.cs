using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.JoinEntities = new HashSet<IngredientRecipe>();
    }

    public virtual ApplicationUser User { get; set; }

    public int IngredientId { get ; set ;}
    public string Description { get; set; }
    public virtual ICollection<IngredientRecipe> JoinEntities { get; set; } 
  }
}
using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }

    public virtual ApplicationUser User { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public virtual ICollection<CategoryRecipe> JoinEntities { get; set; }
  }
}
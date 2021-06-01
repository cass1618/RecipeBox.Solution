namespace RecipeBox.Models
{
  public class CategoryRecipe
  {
    public int CategoryRecipe { get; set; }
    public int RecipeId { get; set; }
    public int CategoryId { get; set; }
    public virtual Recipe Recipe { get; set; }
    public virtual Category Category { get; set; }
  }
}
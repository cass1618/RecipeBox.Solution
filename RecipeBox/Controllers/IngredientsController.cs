using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using RecipeBox.Models;
using System;
using System.Collections.Generic;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IngredientsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    // public async Task<ActionResult> Index()
    public ActionResult Index()
    {
      List<Ingredient> ingredients = _db.Ingredients.ToList();
      return View(ingredients);

      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userIngredients = _db.Ingredients.Where(entry => entry.User.Id == currentUser.Id).ToList();
      // return View(userIngredients);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    // public async Task<ActionResult> 
    public ActionResult Create(Ingredient ingredient)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // ingredient.User = currentUser;
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  
    public ActionResult Details(int id)
    {
      var thisIngredient = _db.Ingredients
        .Include(ingredient => ingredient.JoinEntities)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    
    public ActionResult Edit(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient ingredient)
    {
      _db.Entry(ingredient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
using backend.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly ICustomRepository _customRepository;

        public RecipesController(ILogger<RecipesController> logger, IRepository<Recipe> recipeRepository, ICustomRepository customRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
            _customRepository = customRepository;
        }

        // GET: Recipe/1
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            var recipe = _recipeRepository.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // GET: RecipeAll/1
        [HttpGet("RecipeAll/{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeAll(int id)
        {
            var recipe = await _customRepository.GetRecipeStepsIngredients(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        //[HttpPost]
        //public async Task<ActionResult<Recipe>> PostRecipeAll(Recipe recipe)
        //{
        //    await _customRepository.SaveRecipeAll(recipe);

        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    return recipe;
        //}
    }
}
using backend.Models;
using backend.Models.DataLayer;
using backend.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly ICustomRepository _customRepository;

        public RecipesController(IRepository<Recipe> recipeRepository, ICustomRepository customRepository)
        {
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
        public async Task<ActionResult<RecipeDto>> GetRecipeAll(int id)
        {
            var recipe = await _customRepository.GetRecipeAll(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return new RecipeDto(recipe);
        }


        // GET: Recipes
        [HttpGet]
        public async Task<IEnumerable<RecipeDto>?> GetRecipes(string search, int page = 0, int pageSize = 20)
        {
            if(search == "ALL")
            {
                search = "";
            }
            var result = await _customRepository.GetRecipeAllSearch(search.ToLower(), page, pageSize);
            List<RecipeDto> resultDtos = new List<RecipeDto>();
            if(result.Count > 0)
            {
                foreach(var item in result)
                {
                    resultDtos.Add(new RecipeDto(item));
                }
                return resultDtos;
            }
            else { return null; }
        }

        [HttpGet("api")]
        public async Task<ApiResult<Recipe>?> GetApiRecipes(string search, int pageIndex = 0, int pageSize = 20)
        {
            if (search == "ALL")
            {
                search = "";
            }
            return await _customRepository.GetRecipeApiSearch(search.ToLower(), pageIndex, pageSize);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Recipe>> PostRecipeAll(RecipePreParse recipeIncoming)
        {
            var recipe = (recipeIncoming.GetRecipeWithLists());
            await _customRepository.SaveRecipeAll(recipe);
            return recipe;
        }

        // GET: Recipe/1
        [HttpGet("ForEdit/{id}")]
        public async Task<ActionResult<RecipePreParse>> GetRecipeForEdit(int id)
        {
            var recipe = await _customRepository.GetRecipeAll(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return new RecipePreParse(recipe);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutRecipeAll(RecipePreParse recipeIncoming)
        {
            var recipe = (recipeIncoming.GetRecipeWithLists());
            await _customRepository.UpdateRecipeAll(recipe);
            return NoContent();
        }

        [HttpPost("AddIntResponse")]
        public async Task<IActionResult> AddNoResponse(RecipePreParse recipeIncoming)
        {
            var recipe = (recipeIncoming.GetRecipeWithLists());
            var recipeId = await _customRepository.SaveRecipeAll(recipe);
            return Ok(recipeId);
        }

        [HttpPost("IsDuplicateRecipe")]
        public bool IsDuplicateRecipe(RecipePreParse recipeIncoming)
        {
            return _customRepository.IsDuplicateRecipe(recipeIncoming);
        }
    }
}
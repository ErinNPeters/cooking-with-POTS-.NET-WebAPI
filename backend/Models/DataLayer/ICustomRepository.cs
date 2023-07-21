using backend.Models.Dto;

namespace backend.Models.DataLayer
{
    public interface ICustomRepository
    {
        Task<Recipe> GetRecipeAll(int id);
        Task<List<Recipe>> GetRecipeAllSearch(string criteria);
        Task<int> SaveRecipeAll(Recipe recipe);
        Task UpdateRecipeAll(Recipe recipe);
        bool IsDuplicateRecipe(RecipePreParse recipe);
    }
}

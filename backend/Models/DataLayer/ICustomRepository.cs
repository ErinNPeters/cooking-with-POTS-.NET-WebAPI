namespace backend.Models.DataLayer
{
    public interface ICustomRepository
    {
        Task<Recipe> GetRecipeAll(int id);
        Task<List<Recipe>> GetRecipeAllSearch(string criteria);
        Task SaveRecipeAll(Recipe recipe);
        Task UpdateRecipeAll(Recipe recipe);
    }
}

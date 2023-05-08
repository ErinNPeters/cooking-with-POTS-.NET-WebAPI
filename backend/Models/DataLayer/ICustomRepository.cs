namespace backend.Models.DataLayer
{
    public interface ICustomRepository
    {
        Task<Recipe> GetRecipeStepsIngredients(int id);
        Task SaveRecipeAll(Recipe recipe);
    }
}

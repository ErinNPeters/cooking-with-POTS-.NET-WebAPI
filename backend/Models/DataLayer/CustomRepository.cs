using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer
{
    public class CustomRepository : ICustomRepository
    {
        protected RecipesContext context { get; set; }

        public CustomRepository(RecipesContext ctx)
        {
            context = ctx;
        }

        public async Task<Recipe> GetRecipeStepsIngredients(int id)
        {
            var recipesSet = context.Recipes;
            var ingredientsSet = context.Ingredients;
            var stepsSet = context.Steps;

            var query = from recipes in recipesSet
                        where recipes.RecipeId == id
                        select new Recipe
                        {
                            RecipeId = recipes.RecipeId,
                            Title = recipes.Title,
                            UserId = recipes.UserId,
                            UserName = recipes.UserName,
                            Created = recipes.Created,
                            SauceName = recipes.SauceName,
                            CrockPot = recipes.CrockPot,
                            Ingredients = ingredientsSet.Where(i => i.RecipeId == id).ToList(),
                            Steps = stepsSet.Where(i => i.RecipeId == id).ToList(),
                        };

            return await query.FirstOrDefaultAsync();

        }

        public async Task SaveRecipeAll(Recipe recipe)
        {
            using (var trasaction = context.Database.BeginTransactionAsync())
            {
                try
                {
                   context.Recipes.Add(recipe);
                    context.SaveChanges();

                    recipe.Ingredients.ForEach(ingredient => { ingredient.RecipeId = recipe.RecipeId; });
                    recipe.Steps.ForEach(step => { step.RecipeId = recipe.RecipeId; });

                }
                catch(Exception ex)
                {
                    
                }
            }

        }
    }
}

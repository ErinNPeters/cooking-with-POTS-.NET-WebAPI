﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace backend.Models.DataLayer
{
    public class CustomRepository : ICustomRepository
    {
        protected RecipesContext context { get; set; }

        public CustomRepository(RecipesContext ctx)
        {
            context = ctx;
        }

        public async Task<Recipe> GetRecipeAll(int id)
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

        public async Task<List<Recipe>> GetRecipeAllSearch(string criteria)
        {
            var recipesSet = context.Recipes;
            var ingredientsSet = context.Ingredients;
            var stepsSet = context.Steps;

            var query = from recipes in recipesSet
                        select new Recipe
                        {
                            RecipeId = recipes.RecipeId,
                            Title = recipes.Title,
                            UserId = recipes.UserId,
                            UserName = recipes.UserName,
                            Created = recipes.Created,
                            SauceName = recipes.SauceName,
                            CrockPot = recipes.CrockPot,
                            Ingredients = ingredientsSet.Where(i => i.RecipeId == recipes.RecipeId).ToList(),
                            Steps = stepsSet.Where(i => i.RecipeId == recipes.RecipeId).ToList(),
                        };

            if (!string.IsNullOrWhiteSpace(criteria))
            {
                query = query.Where(entity => entity.Title.ToLower().Contains(criteria) || entity.Ingredients.Any(i => i.Content.ToLower().Contains(criteria))
                                                                      || entity.Steps.Any(s => s.Content.ToLower().Contains(criteria))); 
            }

            return await query.ToListAsync();

        }


        public async Task SaveRecipeAll(Recipe recipe)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                   context.Recipes.Add(recipe);
                    context.SaveChanges();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }

        }
    }
}

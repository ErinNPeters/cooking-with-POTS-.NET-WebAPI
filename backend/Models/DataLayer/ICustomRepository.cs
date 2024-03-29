﻿using backend.Models.Dto;

namespace backend.Models.DataLayer
{
    public interface ICustomRepository
    {
        Task<Recipe> GetRecipeAll(int id);
        Task<List<Recipe>> GetRecipeAllSearch(string criteria, int page, int pageSize);
        Task<int> SaveRecipeAll(Recipe recipe);
        Task UpdateRecipeAll(Recipe recipe);
        bool IsDuplicateRecipe(RecipePreParse recipe);
        Task<SearchGridResult<Recipe>> GetRecipeSearchGridResult(string criteria, int page, int pageSize, string? sortColumn, string? sortOrder);
    }
}

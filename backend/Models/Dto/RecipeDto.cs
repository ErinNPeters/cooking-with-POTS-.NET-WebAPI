using backend.Models.DataLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Dto;

public class RecipeDto
{
    public int RecipeId { get; set; }
    public string Title { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;

    public string? SauceName { get; set; }

    public bool? CrockPot { get; set; }
    public virtual List<IngredientDto> IngredientDtos { get; set; } = new List<IngredientDto>();

    public virtual List<StepDto> StepDtos { get; set; } = new List<StepDto>();

    public RecipeDto(Recipe recipe)
    {
        RecipeId = recipe.RecipeId;
        Title = recipe.Title;
        UserId = recipe.UserId;
        UserName = recipe.UserName;
        SauceName = recipe.SauceName;
        CrockPot = recipe.CrockPot;
        foreach(var ingredient in recipe.Ingredients) { IngredientDtos.Add(new IngredientDto(ingredient)); }
        foreach (var step in recipe.Steps) { StepDtos.Add(new StepDto(step)); }
    }
}

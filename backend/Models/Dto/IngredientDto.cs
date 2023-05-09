using backend.Models.DataLayer;

namespace backend.Models.Dto;

public class IngredientDto
{
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public string Content { get; set; } = null!;

    public IngredientDto(Ingredient ingredient)
    {
        IngredientId = ingredient.IngredientId;
        RecipeId = ingredient.RecipeId;
        Content = ingredient.Content;
    }
}

using backend.Models.DataLayer;

namespace backend.Models.Dto;

public class StepDto
{
    public int StepId { get; set; }

    public int RecipeId { get; set; }

    public string Content { get; set; } = null!;

    public StepDto(Step step)
    {
        StepId = step.StepId;
        RecipeId = step.RecipeId;
        Content = step.Content;
    }

}

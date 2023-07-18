using backend.Models.DataLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace backend.Models.Dto
{
    public class RecipePreParse
    {
        [StringLength(100)]
        public string Title { get; set; } = null!;

        public DateTime Created { get; set; }

        [StringLength(100)]
        public string? SauceName { get; set; }

        public bool? CrockPot { get; set; }

        public string Ingredients { get; set; }

        public string Steps { get; set; }

        public Recipe GetRecipeWithLists()
        {
            var recipe = new Recipe
            {
                Title = Title,
                Created = DateTime.Now,
                SauceName = SauceName,
                CrockPot = CrockPot,
                UserId = "1",
                UserName = "erin@test.com"
            };

            var ingredientsList = Ingredients.Split(new string[] { Environment.NewLine, "\\n", "/n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var ingredient in ingredientsList)
            {
                recipe.Ingredients.Add(new Ingredient { Content = ingredient });
            }
            var stepList = Steps.Split(new string[] { Environment.NewLine, "\\n", "/n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var step in stepList)
            {
                recipe.Steps.Add(new Step { Content = step });
            }
            return recipe;
        }
    }
}

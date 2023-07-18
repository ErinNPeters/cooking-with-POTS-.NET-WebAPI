using backend.Controllers;
using backend.Models.DataLayer;
using backend.Models.Dto;
using Moq;

namespace BackendTests
{
    [TestClass]
    public class RecipeTests
    {
        Mock<ICustomRepository> _mockCustomRepository;
        Mock<backend.Models.DataLayer.IRepository<Recipe>> _mockRepository;
        Recipe _recipe;
        RecipePreParse _recipePreParse;

        [TestInitialize()]
        public void Setup()
        {
            _recipePreParse = new RecipePreParse{
                CrockPot = true,
                Title = "Crock Pot Bourbon Chicken",
                Ingredients = "3 lbs boneless skinless chicken thighs\r\n3 tablespoons cornstarch\r\n¼ cup sliced green onions (or more to taste)",
                Steps = "Mix all sauce ingredients in a small bowl.\r\nPlace chicken in slow cooker, pour sauce over top. Cover and cook on low 6-7 hours or on high 3 hours.",
            };

            _recipe = new Recipe {
                CrockPot = true,
                Title = "Crock Pot Bourbon Chicken",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Content = "3 lbs boneless skinless chicken thighs" },
                    new Ingredient { Content = "3 tablespoons cornstarch" },
                    new Ingredient { Content = "¼ cup sliced green onions (or more to taste)" }
                },
                Steps = new List<Step> { 
                    new Step { Content = "Mix all sauce ingredients in a small bowl." },
                    new Step { Content = "Place chicken in slow cooker, pour sauce over top. Cover and cook on low 6-7 hours or on high 3 hours." }
                }
            };

            _mockCustomRepository = new Mock<ICustomRepository>();
            _mockCustomRepository.Setup(repo => repo.SaveRecipeAll(_recipe));
            _mockRepository = new Mock<backend.Models.DataLayer.IRepository<Recipe>>();
        }
        
        [TestMethod]
        public async Task TestPreParseToPostParse()
        {
            var _controller = new RecipesController(_mockRepository.Object, _mockCustomRepository.Object);
            var result = (await _controller.PostRecipeAll(_recipePreParse)).Value;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Ingredients.Count == 3);
            Assert.IsTrue(result.Steps.Count == 2);
            Assert.IsTrue(result.Ingredients[0].Content == _recipe.Ingredients[0].Content);
        }

        //TO DO: Add test for entries containing excess line breaks.
    }
}
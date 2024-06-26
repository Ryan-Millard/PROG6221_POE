using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Recipe;

namespace RecipeTests
{
	[TestClass]
	public class RecipeTests
	{
		[TestMethod]
		public void TestTotalCaloriesCalculation()
		{
			// Arrange
			var ingredients = new Ingredient[]
			{
				new Ingredient("Rice", 200, "grams", 240, FoodGroup.Starch),
				new Ingredient("Chicken", 150, "grams", 330, FoodGroup.Protein),
				new Ingredient("Broccoli", 100, "grams", 50, FoodGroup.FruitsAndVegetables)
			};
			var steps = new string[]
			{
				"Boil the rice.",
				"Grill the chicken.",
				"Steam the broccoli."
			};
			var recipe = new Recipe("Chicken and Rice", ingredients, steps);

			// Act
			var totalCalories = recipe.TotalCalories;

			// Assert
			Assert.AreEqual(620, totalCalories, "The total calories calculation is incorrect.");
		}
	}
}


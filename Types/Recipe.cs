using System.Linq;

namespace Types.Recipe
{
	public delegate void CaloriesExceededEventHandler(string recipeName, float totalCalories);

	public class Recipe
	{
		public event CaloriesExceededEventHandler? CaloriesExceeded;

		public string Name { get; set; }
		public Ingredient[] Ingredients { get; set; }
		public string[] Steps { get; set; }

		public Recipe(string name, Ingredient[] ingredients, string[] steps)
		{
			Name = name;
			Ingredients = ingredients;
			Steps = steps;
		}

		public Recipe Scale(float scaleFactor)
		{
			var scaledIngredients = Ingredients.Select(ingredient =>
					new Ingredient(ingredient.Name, ingredient.Quantity * scaleFactor,
						ingredient.Unit, ingredient.Calories * scaleFactor, ingredient.Category)
					).ToArray();

			return new Recipe(Name, scaledIngredients, Steps);
		}

		public void Deconstruct(out string name, out Ingredient[] ingredients, out string[] steps)
		{
			name = Name;
			ingredients = Ingredients;
			steps = Steps;
		}

		public void CheckCalories()
		{
			var totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);

			if (totalCalories > 300) CaloriesExceeded?.Invoke(Name, totalCalories);
		}

		public override string ToString()
		{
			var ingredientsString = string.Join("\n", Ingredients.Select(ingredient => $"\t{ingredient}"));
			var stepsString = string.Join("\n", Steps.Select((step, index) => $"\t{index + 1}) {step}"));

			return $"Name: {Name}\n\nIngredients:\n{ingredientsString}\n\nSteps:\n{stepsString}";
		}
	}
}

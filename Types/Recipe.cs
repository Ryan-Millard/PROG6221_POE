using System.Linq;

namespace Types.Recipe
{
	public class Recipe
	{
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
						new Ingredient(ingredient.Name, ingredient.Quantity * scaleFactor, ingredient.Unit)
					).ToArray();

			return new Recipe(Name, scaledIngredients, Steps);
		}

		public void Deconstruct(out string name, out Ingredient[] ingredients, out string[] steps)
		{
			name = Name;
			ingredients = Ingredients;
			steps = Steps;
		}
	}
}

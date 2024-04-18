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
		// this function returns a new Recipe without modifying the "this" Recipe instance
		{
			// return a new Ingredient[] that has had it's quantity scaled
			// by multiplying it by the scaleFactor parameter
			var scaledIngredients = Ingredients.Select(ingredient =>
						new Ingredient(ingredient.Name, ingredient.Quantity * scaleFactor, ingredient.Unit)
					).ToArray();

			return new Recipe(Name, scaledIngredients, Steps);
		}

		public void Deconstruct(out string name, out Ingredient[] ingredients, out string[] steps)
		// typical function for destructuring an obj
		{
			name = Name;
			ingredients = Ingredients;
			steps = Steps;
		}
	}
}

namespace Types
{
	namespace Recipe
	{
		public class Recipe
		{
			public string Name { get; set; }
			public Ingredient[] Ingredients { get; set; }
			public byte NumSteps { get; set; }

			public Recipe(string name, byte numIngredients, Ingredient[] ingredients, byte numSteps)
			{
				Name = name;
				Ingredients = ingredients;
				NumSteps = numSteps;
			}
		}
	}
}

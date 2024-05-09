namespace Types.Recipe
{
	public class Ingredient
	{
		public string Name { get; set; }
		public float Quantity { get; set; }
		public string Unit { get; set; }
		public float Calories { get; set; }
		public FoodGroup Category { get; set; }

		public Ingredient(string name, float quantity, string unit, float calories, FoodGroup category)
		{
			// ensure that the quantity is a natural number
			Quantity = (quantity > 0)
					? quantity
					: throw new ArgumentOutOfRangeException("Ingredient quantity may not be less than or equal to 0 (zero).");
			Name = name;
			Unit = unit;
			Calories = calories;
			Category = category;
		}

		public override string ToString()
		{
			return $"{Name} ({Quantity} {Unit}) ({Calories} calories) ({Category}))";
		}

		public void Deconstruct(out string name, out float quantity, out string unit,
								out float calories, out FoodGroup Category)
		{
			name = Name;
			quantity = Quantity;
			unit = Unit;
			calories = Calories;
			category = Category;
		}
	}
}

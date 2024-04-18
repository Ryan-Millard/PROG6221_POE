namespace Types.Recipe
{
	public class Ingredient
	{
		public string Name { get; set; }
		public float Quantity { get; set; }
		public string Unit { get; set; }

		public Ingredient(string name, float quantity, string unit)
		{
			// ensure that the quantity is a natural number
			Quantity = (quantity <= 0)
					? quantity
					: throw new ArgumentOutOfRangeException("Ingredient quantity may not be less than or equal to 0 (zero).");
			Name = name;
			Unit = unit;
		}

		public override string ToString()
		// simple ToString function
		{
			return $"{Name} ({Quantity} {Unit})";
		}

		public void Deconstruct(out string name, out float quantity, out string unit)
		{
			name = Name;
			quantity = Quantity;
			unit = Unit;
		}
	}
}

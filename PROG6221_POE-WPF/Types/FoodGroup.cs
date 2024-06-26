using System;
using System.ComponentModel;
using System.Reflection;

namespace Types.Recipe
{
	public enum FoodGroup
	{
		[Description("starch")]
		Starch = 1,

		[Description("fruits and vegetables")]
		FruitsAndVegetables = 2,

		[Description("legumes")]
		Legumes = 3,

		[Description("protein")]
		Protein = 4,

		[Description("dairy")]
		Dairy = 5,

		[Description("fats and oil")]
		FatsAndOil = 6,

		[Description("water")]
		Water = 7,

		[Description("other")]
		Other = 8
	}

	public static class FoodGroupExtensions
	{
		public static string GetDescription(this FoodGroup value)
		{
			FieldInfo? field = value.GetType().GetField(value.ToString());

			if(field == null) return value.ToString();

			var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

			return attribute == null ? value.ToString() : attribute.Description;
		}
	}
}

using System;
using System.ComponentModel;
using System.Reflection;

namespace Types.Recipe
{
	public enum FoodGroup
	{
		[Description("starch")]
		Starch,

		[Description("fruits and vegetables")]
		FruitsAndVegetables,

		[Description("legumes")]
		Legumes,

		[Description("protein")]
		Protein,

		[Description("dairy")]
		Dairy,

		[Description("fats and oil")]
		FatsAndOil,

		[Description("water")]
		Water,

		[Description("other")]
		Other
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

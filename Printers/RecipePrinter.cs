using System;
using Types.Recipe;
using FormattedConsole;
using System.Linq;

namespace Printer
{
	public struct RecipePrinter
	{
		public static void Print(Recipe recipe)
		{
			// destructure recipe
			var (name, ingredients, steps) = recipe;
			var numSteps = 0;
			var horizontalRule = ("-------------------------------------------------------------------------",
					ConsoleColor.Green);

			// print to array of tuples to the console
			PrettyConsole.Write(
				Console.WriteLine,

				horizontalRule,
				(recipe.Name, ConsoleColor.Gray),
				horizontalRule,

				(string.Join("\n", ingredients.Select(ing => ing.ToString())),
				ConsoleColor.White),

				horizontalRule,

				(string.Join("\n", steps.Select(step => {
							numSteps++;
							return $"{numSteps}) {step.ToString()}";
						})),
				ConsoleColor.White),
				horizontalRule
			);

			Console.WriteLine();
		}
	}
}

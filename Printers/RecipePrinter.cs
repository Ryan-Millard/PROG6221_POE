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
			var (name, ingredients, steps) = recipe;
			var numSteps = 0;
			var horizontalRule = ("-------------------------------------------------------------------------\n",
					ConsoleColor.Green, ConsoleColor.Black);

			PrettyConsole.Write(
				Console.WriteLine,

				horizontalRule,
				(recipe.Name, ConsoleColor.Gray, ConsoleColor.Red),
				horizontalRule,

				(string.Join("\n", ingredients.Select(ing => ing.ToString())),
				ConsoleColor.Black, ConsoleColor.Yellow),

				(string.Join("\n", steps.Select(step => {
							numSteps++;
							return $"{numSteps}) {step.ToString()}";
						})),
				ConsoleColor.White, ConsoleColor.Blue),
				horizontalRule
			);

			Console.WriteLine();
		}
	}
}

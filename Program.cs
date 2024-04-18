using System;
using Types.Recipe;
using Printer;
using Prompts;
using FormattedConsole;

namespace Program
{
	static class Program
	{
		static void Main(string[] args)
		{
			PrettyConsole.Write(Console.WriteLine, ("PROG6221 POE Part 1", ConsoleColor.White, ConsoleColor.Magenta));

			var initialRecipe = CreateNewRecipe();
			RecipePrinter.Print(initialRecipe);

			HandleUserInput(initialRecipe);
		}

		private static Recipe CreateNewRecipe()
		{
			var recipeName = RecipePrompt.Prompt("Enter the name of the recipe: ");
			var recipeIngredients = RecipePrompt.PromptIngredients("Enter Ingredients in the following form: name quantity unit e.g. sugar 2 spoons");
			var recipeSteps = RecipePrompt.PromptSteps("Enter the recipe's steps: ");

			return new Recipe(recipeName, recipeIngredients, recipeSteps);
		}

		private static void DisplayOptions()
		{
			Console.WriteLine("Choose an option below:");
			var options = new []{
				"1) Create a new recipe (CAUTION)",
				"2) Print the original recipe to the screen",
				"3) Scale the recipe up or down, and then print it to the screen",
				"4) Exit Application (Warning - Your recipe will not be saved)"
			};

			foreach(var option in options)
				PrettyConsole.Write(Console.WriteLine, (option, ConsoleColor.Black, ConsoleColor.Yellow));
		}

		private static void HandleUserInput(Recipe initialRecipe)
		{
			while (true)
			{
				DisplayOptions();
				Console.Write("Enter your choice: ");
				string userInput = Console.ReadLine()?? " ";	// non-null, but still a white space
				if (string.IsNullOrWhiteSpace(userInput))
				{
					PrettyConsole.Write(Console.WriteLine,
							("Invalid input format. Please enter your choice as a number in the range 1-3.",
							 ConsoleColor.White, ConsoleColor.DarkRed));
					continue;	// re-prompt the user for valid input
				}

				switch (userInput)
				{
					case "1":
						PrettyConsole.Write(Console.WriteLine,
							("This will overwrite the previous recipe you created. Do you wish to proceed? [y/n]: ",
							 ConsoleColor.DarkYellow, ConsoleColor.Black));

						ConsoleKeyInfo keyInfo = default(ConsoleKeyInfo);
						for(; keyInfo.KeyChar != 'y' && keyInfo.KeyChar != 'n';)
							keyInfo = Console.ReadKey(intercept: true);

						if (keyInfo.KeyChar == 'n')	// user chose "n" (no option)
						{
							PrettyConsole.Write(Console.WriteLine,
								("Cancelling the process...", ConsoleColor.Black, ConsoleColor.Gray));
							break;
						}

						// user chose "y" (yes option)
							PrettyConsole.Write(Console.WriteLine, ("Proceeding...", ConsoleColor.Black, ConsoleColor.Gray));
							initialRecipe = CreateNewRecipe();
						break;

					case "2":

						while(true)
						{
							PrettyConsole.Write(Console.Write,
								("Enter the factor by which you would like to scale the recipe:\nScaling factor: ",
								 ConsoleColor.Black, ConsoleColor.Gray));

							if(float.TryParse(Console.ReadLine() ?? "", out float scaleFactor))
							{
								// Call the Scale method with the parsed scaling factor
								RecipePrinter.Print(initialRecipe.Scale(scaleFactor));
								break;	// exit loop as the recipe has been successfully scaled
							}
							Console.WriteLine("Invalid input! Please enter a valid scaling factor.");
						}
						break;

					case "3":	// exit the application
						PrettyConsole.Write(Console.WriteLine,
								("Exiting application...", ConsoleColor.Red, ConsoleColor.Black));
						Environment.Exit(0);
						break;
					default:
						PrettyConsole.Write(Console.WriteLine,
								("Invalid choice. Please enter a valid option (1, 2, or 3).",
								 ConsoleColor.Red, ConsoleColor.Black));
						break;
				}
			}
		}

	}

}

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
			PrettyConsole.Write(Console.WriteLine, ("PROG6221 POE Part 1", ConsoleColor.White));

			// long-living recipe that is only altered when a brand new recipe is made
			var initialRecipe = CreateNewRecipe();
			RecipePrinter.Print(initialRecipe);

			// prompt user to create a new recipe, display it, scale it, or exit app
			HandleUserInput(initialRecipe);
		}

		private static Recipe CreateNewRecipe()
		// creates Recipe obj and returns new one
		{
			var recipeName = RecipePrompt.Prompt("Enter the name of the recipe: ");
			var recipeIngredients = RecipePrompt.PromptIngredients("Enter Ingredients in the following form: Name Quantity Unit Calories Food-Group-ID (e.g. steak 500 grams 300 4)");
			var recipeSteps = RecipePrompt.PromptSteps("Enter the recipe's steps: ");

			var recipe = new Recipe(recipeName, recipeIngredients, recipeSteps);

			recipe.CaloriesExceeded += (name, totalCalories) => PrettyConsole.Write(Console.WriteLine,
					($"Warning: The calories in {name} ({totalCalories} calories) exceed 300!",
					 ConsoleColor.Red));
			recipe.CheckCalories();

			return recipe;
		}

		private static void DisplayOptions()
		// prompts the user to choose an option by number from the array that is printed
		{
			Console.WriteLine("Choose an option below:");
			var options = new []{
				"1) Create a new recipe (CAUTION)",
				"2) Print the original recipe to the screen",
				"3) Scale the recipe up or down, and then print it to the screen",
				"4) Exit Application (Warning - Your recipe will not be saved)\n"
			};

			foreach(var option in options)
				PrettyConsole.Write(Console.WriteLine, (option, ConsoleColor.Magenta));
		}

		private static void HandleUserInput(Recipe initialRecipe)
		{
			while (true)	// app will never end until the user asks it to
			{
				// prompt user to choose from the menu list
				DisplayOptions();
				Console.Write("Enter your choice: ");
				string userInput = Console.ReadLine()?? " ";	// non-null, but still a white space

				if (string.IsNullOrWhiteSpace(userInput))
				{
					PrettyConsole.Write(Console.WriteLine,
							("Invalid input format. Please enter your choice as a number in the range 1-3.",
							 ConsoleColor.White));
					continue;	// re-prompt the user for valid input
				}

				switch (userInput)
				{
					case "1":	// user chose to create a new recipe
						PrettyConsole.Write(Console.WriteLine,
							("This will overwrite the previous recipe you created. Do you wish to proceed? [y/n]: ",
							 ConsoleColor.DarkYellow));

						// prompt user to decide if they want to overwrite their
						// previously saved recipe
						ConsoleKeyInfo keyInfo = default(ConsoleKeyInfo);
						while(keyInfo.KeyChar != 'y' && keyInfo.KeyChar != 'n')
							keyInfo = Console.ReadKey(intercept: true);

						if (keyInfo.KeyChar == 'n')	// user chose "n" (no option)
						{
							PrettyConsole.Write(Console.WriteLine,
								("Cancelling the process...", ConsoleColor.White));
							break;
						}

						// user chose "y" (yes option)
							PrettyConsole.Write(Console.WriteLine, ("Proceeding...", ConsoleColor.White));
							initialRecipe = CreateNewRecipe();
						break;

					case "2":	// user chose to have their recipe printed to the console
						RecipePrinter.Print(initialRecipe);
						break;

					case "3":	// user chose to scale the recipe
						while(true)
						{
							PrettyConsole.Write(Console.Write,
								("Enter the factor by which you would like to scale the recipe:\nScaling factor: ",
								 ConsoleColor.Green));

							// ensure the factor by which the user wants to scale is a float
							if(float.TryParse(Console.ReadLine() ?? "", out float scaleFactor))
							{
								// Call the Scale method with the parsed scaling factor
									// this method returns a new Recipe obj
									// the new obj does not need to be saved
								PrettyConsole.Write(Console.WriteLine,
										("\nScaled Recipe:", ConsoleColor.Blue));

								var scaledRecipe = initialRecipe.Scale(scaleFactor);
								scaledRecipe.CaloriesExceeded += (name, totalCalories) => PrettyConsole.Write(Console.WriteLine,
										($"Warning: The calories in the scaled recipe, {name} ({totalCalories} calories), exceed 300!",
										 ConsoleColor.Red));
								scaledRecipe.CheckCalories();
								RecipePrinter.Print(scaledRecipe);
								Console.WriteLine();
								break;	// exit loop as the recipe has been successfully scaled
							}
							Console.WriteLine("Invalid input! Please enter a valid scaling factor.");
						}
						break;

					case "4":	// user wants to exit the application
						PrettyConsole.Write(Console.WriteLine,
								("Exiting application...", ConsoleColor.Red));
						// exit function to gracefully close the app
						Environment.Exit(0);
						break;

					default:	// user's input does not match that of the menu
						PrettyConsole.Write(Console.WriteLine,
								("Invalid choice. Please enter a valid option (1, 2, or 3).",
								 ConsoleColor.Red));
						break;
				}
			}
		}

	}

}

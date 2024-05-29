using System;
using Types.Recipe;
using Printer;
using Prompts;
using FormattedConsole;
using System.Linq;

namespace Program
{
	static class Program
	{
		static void Main(string[] args)
		{
			PrettyConsole.Write(Console.WriteLine, ("PROG6221 POE Part 1", ConsoleColor.White));

			var recipeList = new SortedList<string, Recipe>(10);
			var initialRecipe = CreateNewRecipe();
			recipeList.Add(initialRecipe.Name, initialRecipe);

			foreach(var recipe in recipeList)
				RecipePrinter.Print(recipe.Value);

			// prompt user to create a new recipe, display it, scale it, or exit app
			HandleUserInput(recipeList);
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
				"1) Create a new recipe",
				"2) Choose a recipe and print it to the screen",
				"3) Scale a recipe up or down, and then print it to the screen",
				"4) Exit Application (Warning - Your recipe will not be saved)\n"
			};

			foreach(var option in options)
				PrettyConsole.Write(Console.WriteLine, (option, ConsoleColor.Magenta));
		}

		private static void HandleUserInput(SortedList<string, Recipe> recipeList)
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
							var newRecipe = CreateNewRecipe();
							recipeList.Add(newRecipe.Name, newRecipe);
						break;

					case "2":	// user chose to scale a recipe
						while(true)
						{
							// print all recipe names to the screen for the user to choose one from
							PrettyConsole.Write(Console.WriteLine,
									(string.Join("\n", recipeList.Select(
											 (recipe, index) => $"{index + 1}) {recipe.Value.Name}")),
									 ConsoleColor.Blue));

							Console.Write("Enter the number of the recipe that you would like to print: ");
							string recipeIndexChosen = Console.ReadLine()?? " ";	// non-null, but still a white space
							if(string.IsNullOrWhiteSpace(recipeIndexChosen))
							{
								PrettyConsole.Write(Console.WriteLine,
										("Invalid input format. Please enter your choice as a number .",
										 ConsoleColor.White));
								continue;	// re-prompt the user for valid input
							}

							int index;
							if(!int.TryParse(recipeIndexChosen, out index) || index < 1 || index > recipeList.Count)
							{
								// Handle invalid input
								PrettyConsole.Write(Console.WriteLine, ("Invalid input format or index out of range. Please enter a valid index.", ConsoleColor.White));
								continue;
							}

							RecipePrinter.Print(recipeList.Values[index-1]);
							break;
						}
						break;

					case "3":	// user chose to scale a recipe
						while(true)
						{
							// print all recipe names to the screen for the user to choose one from
							PrettyConsole.Write(Console.WriteLine,
									(string.Join("\n", recipeList.Select(
											 (recipe, index) => $"{index + 1}) {recipe.Value.Name}")),
									 ConsoleColor.Blue));

							Console.Write("Enter the number of the recipe that you would like to scale: ");
							string recipeIndexChosen = Console.ReadLine()?? " ";	// non-null, but still a white space
							if(string.IsNullOrWhiteSpace(recipeIndexChosen))
							{
								PrettyConsole.Write(Console.WriteLine,
										("Invalid input format. Please enter your choice as a number .",
										 ConsoleColor.White));
								continue;	// re-prompt the user for valid input
							}

							int index;
							if(!int.TryParse(recipeIndexChosen, out index) || index < 1 || index > recipeList.Count)
							{
								// Handle invalid input
								PrettyConsole.Write(Console.WriteLine, ("Invalid input format or index out of range. Please enter a valid index.", ConsoleColor.White));
								continue;
							}
							var recipeChosen = recipeList.Values[index-1];

							// Prompt the user to enter a value to scale the recipe by
							PrettyConsole.Write(Console.Write,
								("Enter the factor by which you would like to scale the recipe: ",
								 ConsoleColor.Green));

							// ensure the factor by which the user wants to scale is a float
							if(float.TryParse(Console.ReadLine() ?? "", out float scaleFactor))
							{
								// Call the Scale method with the parsed scaling factor
									// this method returns a new Recipe obj
									// the new obj does not need to be saved
								PrettyConsole.Write(Console.WriteLine,
										("\nScaled Recipe:", ConsoleColor.Blue));

								var scaledRecipe = recipeChosen.Scale(scaleFactor);
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

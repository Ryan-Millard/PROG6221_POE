using System;
using FormattedConsole;
using Types.Recipe;
using System.Collections.Generic;

namespace Prompts
{
	public static class RecipePrompt
	{
		public static string Prompt(in string promptMessage)
		{
			while(true)
			{
				PrettyConsole.Write(Console.WriteLine, ("Enter the name of the recipe: ", ConsoleColor.Black, ConsoleColor.Green));

				var userInput = Console.ReadLine();
				if(string.IsNullOrWhiteSpace(userInput))
				{
					PrettyConsole.Write( Console.WriteLine,
							("The recipe must have a name.",
							 ConsoleColor.DarkRed, ConsoleColor.Black));
					continue;	// re-prompt the user for valid input
				}

				return userInput; // Return input if not empty/whitespace
			}
		}

		public static string[] PromptSteps(string promptMessage)
		{
			var inputList = new List<string>();

			PrettyConsole.Write(Console.WriteLine,
					(promptMessage, ConsoleColor.Black, ConsoleColor.Green),
					("Type \"DONE\" when you are finished.", ConsoleColor.Green, ConsoleColor.Black));

			for(int i = 1; true; i++)	// infinite until user types "DONE"
			{
				Console.Write($"{i}) ");
				var nextInput = Console.ReadLine();	// read input and check if the user has entered all ingredients

				if(string.IsNullOrWhiteSpace(nextInput))	// ensure the input is truthy
				{
					PrettyConsole.Write(Console.WriteLine, ("Invalid input. You must enter a step", ConsoleColor.White, ConsoleColor.DarkRed));
					i--; continue;	// repeat & re-prompt the user for valid input
				}

				if(nextInput.ToLower() == "done")
				{
					if(inputList.Count > 0)
						return inputList.ToArray();	// only exit when user chooses to

					// user has entered nothing
					PrettyConsole.Write(Console.WriteLine,
							("You must enter the recipe's steps.", ConsoleColor.White, ConsoleColor.DarkRed));
					i--; continue;	// repeat & re-prompt the user for valid input
				}

				inputList.Add(nextInput.Trim());
			}
		}

		public static Ingredient[] PromptIngredients(string promptMessage)
		{
			var inputList = new List<Ingredient>();
			PrettyConsole.Write(Console.WriteLine,
					(promptMessage, ConsoleColor.Black, ConsoleColor.Green),
					("Type \"DONE\" when you are finished.", ConsoleColor.Green, ConsoleColor.Black));

			for(int i = 1; true; i++)	// infinite until user types "DONE"
			{
				Console.Write($"{i}) ");
				var nextListItem = Console.ReadLine();	// next to be appended to inputList

				if(string.IsNullOrWhiteSpace(nextListItem))	// ensure user input is truthy
				{
					PrettyConsole.Write( Console.WriteLine,
						("Invalid input. You need to enter an ingredient.",
						 ConsoleColor.White, ConsoleColor.DarkRed));
					i--;
					continue;
				}

				if(nextListItem.ToLower() == "done")
				{
					if(inputList.Count > 0)
						return inputList.ToArray();	// only exit when user chooses to

					// user has entered nothing
					PrettyConsole.Write(Console.WriteLine,
							("You must enter the recipe's ingredients.", ConsoleColor.White, ConsoleColor.DarkRed));
					i--; continue;	// repeat & re-prompt the user for valid input
				}

				var fields = nextListItem.Trim().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
				if(fields.Length != 3)
				{
					PrettyConsole.Write( Console.WriteLine,
						("Invalid input format. Please enter the ingredient in the following format: Name Quantity Unit",
							 ConsoleColor.White, ConsoleColor.DarkRed));
					i--;
					continue;
				}

				if(!float.TryParse(fields[1], out float quantity))
				{
					PrettyConsole.Write( Console.WriteLine,
							("Invalid input format. Please enter the ingredient in the following format: Name Quantity Unit",
							 ConsoleColor.White, ConsoleColor.DarkRed));
					continue;
				}

				inputList.Add(new Ingredient(fields[0], quantity, fields[2]));
			}
		}

	}
}


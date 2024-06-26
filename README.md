# [PROG6221 POE](https://github.com/Ryan-Millard/PROG6221_POE)

# .NET Recipe Management App

This repository contains a C# program for a simple recipe management system.

## Overview

This program allows users to create, view, and scale recipes. It consists of the following components:

- [`Program.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Program.cs): Contains the main entry point of the program and user interaction logic.
- [`Recipe.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Recipe.cs): Defines the `Recipe` class, representing a recipe with a name, list of ingredients, and steps. Provides methods for scaling the recipe.
- [`Ingredient.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Ingredient.cs): Defines the `Ingredient` class, representing an ingredient with a name, quantity and measurement of that quantity, number of calories, and a food group category.
- [`FoodGroup.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/FoodGroup.cs): Defines the `FoodGroup` enum, representing a food group type that consists of a description and index, as well as a static extension class that uses reflection to retrieve the description of the instance as a string.
- [`RecipePrompt.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Prompts/RecipePrompt.cs): Contains static methods for prompting users to input recipe information, such as name, ingredients, and steps.
- [`RecipePrinter.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Printers/RecipePrinter.cs): Contains a struct `RecipePrinter` with a static method to print a recipe to the console.
- [`Write.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/FormattedConsole/Write.cs): Contains an enhanced Console.Write/WriteLine function, `Write`, that requires an Action<string> that must be Console.Write/WriteLine, and an unlimited number of string and ConsoleColor tuples (which define the text content and color of that text to be printed to the console). It uses the boolean method, IsConsoleWriteMethod, to ensure the Action<string> is one of the two methods, and then sets the color of the console before passing the text as an argument to the Action<string>.

## Prerequisite Requirements

1. .NET installed on your device

## Usage

To run the program, follow these steps:

1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE.git
```

2. Open the solution in Visual Studio, your preferred C# IDE, or in your terminal.
3. Build the solution either using GUI or with the .NET CLI using the following command:
```bash
  cd PROG6221_POE && dotnet build
```
4. Run the program (`PROG6221_POE.exe`) within your IDE or from your terminal using:
```bash
  ./PROG6221_POE.exe
```

To test the program, follow these steps:

1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE.git
```

2. Open the solution in Visual Studio, your preferred C# IDE, or in your terminal.
3. Build the solution either using GUI or with the .NET CLI using the following command:
```bash
  cd PROG6221_POE && dotnet build
```
4. Test the program from the CLI:
```bash
  cd ../PROG6221_POE.Tests && dotnet build
```

## Features

- Create new recipes, storing them in a SortedList<string, Recipe>, where the recipe's name is the key. These recipes are stored in the computers memory, and are thus not permanent.
- Print the the name of every recipe to the screen in alphabetical order, allowing the user to choose one to display the full contents of.
- Scale chosen recipes up or down by a specified factor and print it to the screen.
- Exit the application.

## License

This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/LICENSE) file for details.

## Contributors

- [Ryan Millard](https://github.com/Ryan-Millard)


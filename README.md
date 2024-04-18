# PROG6221 POE

This repository contains a C# program for a simple recipe management system.

## Overview

This program allows users to create, view, and scale recipes. It consists of the following components:

- [`Program.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/Program.cs): Contains the main entry point of the program and user interaction logic.
- [`Recipe.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/Types/Recipe.cs): Defines the `Recipe` class, representing a recipe with a name, list of ingredients, and steps. Provides methods for scaling the recipe.
- [`Ingredient.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/Types/Ingredient.cs): Defines the `Ingredient` class, representing an ingredient with a name, quantity, and unit.
- [`RecipePrompt.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/Prompts/RecipePrompt.cs): Contains static methods for prompting users to input recipe information, such as name, ingredients, and steps.
- [`RecipePrinter.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/Printers/RecipePrinter.cs): Contains a struct `RecipePrinter` with a static method to print a recipe to the console.

## Usage

To use the program, follow these steps:

1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE.git
```

3. Open the solution in Visual Studio or your preferred C# IDE.
4. Build the solution.
5. Run the program (`PROG6221_POE.exe`) from the command line or within the IDE.

## Features

- Create a new recipe with a name, list of ingredients, and steps.
- Print the original recipe to the screen.
- Scale the recipe up or down by a specified factor and print it to the screen.
- Exit the application.

## License

This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/LICENSE) file for details.

## Contributors

- [Ryan Millard](https://github.com/Ryan-Millard)


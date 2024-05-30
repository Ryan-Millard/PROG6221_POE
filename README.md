# [PROG6221 POE](https://github.com/Ryan-Millard/PROG6221_POE)

# .NET Recipe Management App

This repository contains a C# program for a simple recipe management system.

## Overview

This program allows users to create, view, and scale recipes. It consists of the following components:

- [`PROG6221_POE/Program.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Program.cs): Contains the main entry point of the program and user interaction logic.
- [`PROG6221_POE/Recipe.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Recipe.cs): Defines the `Recipe` class, representing a recipe with a name, list of ingredients, and steps. Provides methods for scaling the recipe.
- [`PROG6221_POE/Ingredient.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Ingredient.cs): Defines the `Ingredient` class, representing an ingredient with a name, quantity, and unit.
- [`PROG6221_POE/RecipePrompt.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Prompts/RecipePrompt.cs): Contains static methods for prompting users to input recipe information, such as name, ingredients, and steps.
- [`PROG6221_POE/RecipePrinter.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Printers/RecipePrinter.cs): Contains a struct `RecipePrinter` with a static method to print a recipe to the console.

## Usage

To use the program, follow these steps:

1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE.git
```

3. Open the solution in Visual Studio, your preferred C# IDE, or in your terminal.
4. Build the solution either using GUI or with the .NET CLI using the following command:
```bash
  dotnet build
```
5. Run the program (`PROG6221_POE.exe`) within your IDE or from your terminal using:
```bash
  ./PROG6221_POE.exe
```

## Features

- Create a new recipe with a name, list of ingredients, and steps.
- Print the original recipe to the screen.
- Scale the recipe up or down by a specified factor and print it to the screen.
- Exit the application.

## License

This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/LICENSE) file for details.

## Contributors

- [Ryan Millard](https://github.com/Ryan-Millard)


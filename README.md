# [PROG6221 POE]([https://github.com/Ryan-Millard/PROG6221_POE](https://github.com/Ryan-Millard/PROG6221_POE/tree/wpf))

# .NET WPF Recipe Management App

This repository contains a C# program for a simple recipe management system.

## Overview

This program allows users to create, view, and scale recipes. It consists of the following components:

- [`Program.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Program.cs): Contains the main entry point of the program and user interaction logic.
- [`Recipe.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Recipe.cs): Defines the `Recipe` class, representing a recipe with a name, list of ingredients, and steps. Provides methods for scaling the recipe.
- [`Ingredient.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/Ingredient.cs): Defines the `Ingredient` class, representing an ingredient with a name, quantity and measurement of that quantity, number of calories, and a food group category.
- [`FoodGroup.cs`](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/PROG6221_POE/Types/FoodGroup.cs): Defines the `FoodGroup` enum, representing a food group type that consists of a description and index, as well as a static extension class that uses reflection to retrieve the description of the instance as a string.

## Features
- Add new recipes with ingredients and steps.
- View details of each recipe.
- Filter recipes by ingredient name, food group, and maximum calories.
- Scale recipes by a given factor.
- Clear all recipes and filters.

## Project Structure
- **RecipeApp.MainWindow**: Main window for managing recipes.
- **RecipeApp.RecipeDetailsWindow**: Window for displaying detailed recipe information.
- **Types.Recipe**: Namespace containing the `Recipe` and `Ingredient` classes, as well as the `FoodGroup` enumeration.

## Prerequisite Requirements
1. Ensure you have .NET installed on your system.

## Usage
To run the program, follow these steps:
1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE/tree/wpf.git
```
2. Open the solution in Visual Studio, your preferred C# IDE, or in your terminal.
3. Build the solution either using GUI or with the .NET CLI using the following command:
```bash
  cd PROG6221_POE-WPF && dotnet build
```
4. Run the program (`PROG6221_POE.exe`) within your IDE or from your terminal using:
```bash
  ./PROG6221_POE-WPF.exe
```
- Add a new recipe by filling out the name, ingredients, and steps, and clicking "Add Recipe."
- View recipes by selecting them from the list. Recipe details are shown in a new window.
- Use the filters to narrow down recipes by ingredient, food group, or calories.
- Scale a recipe's ingredients by entering a scale factor in the details window.
- Clear all recipes or filters using the respective buttons.

To test the program, follow these steps:
1. Clone the repository:
```bash
  git clone git clone https://github.com/Ryan-Millard/PROG6221_POE/tree/wpf.git
```
2. Open the solution in Visual Studio, your preferred C# IDE, or in your terminal.
3. Build the solution either using GUI or with the .NET CLI using the following command:
```bash
  cd PROG6221_POE-WPF && dotnet build
```
4. Test the program from the CLI:
```bash
  cd ../PROG6221_POE-WPF.Tests && dotnet build
```

## Error Handling
- Invalid ingredient or step entries will result in an error message.
- Recipes exceeding 300 calories trigger a warning message.
- Only positive numbers are allowed for ingredient quantities and scale factors.

## Code Overview
### MainWindow.xaml
Contains the layout for the main window, including the textboxes for recipe entry, listbox for displaying recipes, and filter controls.

### RecipeDetailsWindow.xaml
Contains the layout for the details window, displaying the full recipe and allowing for scaling the recipe.

### Recipe.cs
Defines the `Recipe` class, including methods for calculating total calories, scaling the recipe, and checking for calorie limits.

### Ingredient.cs
Defines the `Ingredient` class, representing individual ingredients in a recipe.

### FoodGroup.cs
Defines the `FoodGroup` enumeration, categorizing ingredients into different food groups.

### MainWindow.xaml.cs
Contains the logic for the main window, including adding recipes, filtering the list of recipes, and handling events like button clicks.

### RecipeDetailsWindow.xaml.cs
Contains the logic for the details window, including displaying the recipe details and handling the scaling of recipes.


## License
This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/Ryan-Millard/PROG6221_POE/blob/main/LICENSE) file for details.

## Contributors

- [Ryan Millard](https://github.com/Ryan-Millard)


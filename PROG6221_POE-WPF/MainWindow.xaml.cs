using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Types.Recipe;

namespace RecipeApp
{
	public partial class MainWindow : Window
	{
		private List<Recipe> recipes;

		public MainWindow()
		{
			InitializeComponent();
			recipes = new List<Recipe>();
			PopulateFoodGroupComboBox();
		}

		private void PopulateFoodGroupComboBox()
		{
			FilterFoodGroupComboBox.ItemsSource = Enum.GetValues(typeof(FoodGroup))
				.Cast<FoodGroup>()
				.Select(fg => fg.GetDescription())
				.ToList();
		}

		private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
		{
			string name = RecipeNameTextBox.Text;
			string[] ingredientsInput = IngredientsTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			List<Ingredient> ingredients = new List<Ingredient>();
			bool validUserInput = true;

			foreach (var line in ingredientsInput)
			{
				var parts = line.Split(',');
				if (parts.Length != 5)
				{
					validUserInput = false;
					MessageBox.Show("Not enough information for the recipe has been entered.",
							"Error", MessageBoxButton.OK, MessageBoxImage.Error);
					break;
				}

				string ingredientName = parts[0].Trim();
				string ingredientCategory = parts[4].Trim();
				ingredientCategory = char.ToUpper(ingredientCategory[0]) + ingredientCategory.Substring(1);
				if (float.TryParse(parts[1].Trim(), out float quantity) &&
						float.TryParse(parts[3].Trim(), out float calories) &&
						Enum.TryParse(ingredientCategory, out FoodGroup category))
				{
					string unit = parts[2].Trim();
					ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, category));
				}
				else
				{
					validUserInput = false;
					MessageBox.Show(
							"Invalid input. Quantity and calories must be a number and Category must be part of the pre-defined list of food groups",
							"Error", MessageBoxButton.OK, MessageBoxImage.Error);
					break;
				}
			}

			if (validUserInput)
			{
				string stepsText = StepsTextBox.Text;
				string[] steps = stepsText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

				if (steps.Length >= 1 && !string.IsNullOrWhiteSpace(stepsText))
				{
					Recipe recipe = new Recipe(name, ingredients.ToArray(), steps);
					recipe.CaloriesExceeded += (name, totalCalories) => MessageBox.Show($"Warning: The calories in {name} ({totalCalories} calories) exceed 300!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					recipe.CheckCalories();
					recipes.Add(recipe);

					// Sort recipes alphabetically by name
					recipes = recipes.OrderBy(r => r.Name).ToList();

					// Update ListBox
					UpdateRecipesListBox();

					RecipeNameTextBox.Clear();
					IngredientsTextBox.Clear();
					StepsTextBox.Clear();
				}
				else
				{
					MessageBox.Show("Please enter the recipe's steps.", "Error",
							MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void UpdateRecipesListBox()
		{
			var filteredRecipes = FilterRecipes();

			RecipesListBox.Items.Clear();
			foreach (var recipe in filteredRecipes)
			{
				RecipesListBox.Items.Add(recipe.Name);
			}
		}

		private List<Recipe> FilterRecipes()
		{
			string ingredientName = FilterIngredientName.Text.ToLower();
			string? foodGroupDescription = FilterFoodGroupComboBox.SelectedItem as string;
			float maxCalories = float.MaxValue;

			if (!string.IsNullOrWhiteSpace(FilterMaxCalories.Text) && !float.TryParse(FilterMaxCalories.Text, out maxCalories))
			{
				MessageBox.Show("Invalid maximum calories input. It must be a number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return new List<Recipe>();
			}

			var filteredRecipes = recipes;
			// filter by ingredient name
			filteredRecipes = filteredRecipes.Where(recipe =>
					(string.IsNullOrEmpty(ingredientName) ||
					 recipe.Ingredients.Any(ing => ing.Name.ToLower().Contains(ingredientName)))
					).ToList();
			// filter by food group (called category)
			filteredRecipes = filteredRecipes.Where(recipe =>
					(string.IsNullOrEmpty(foodGroupDescription) || recipe.Ingredients.Any(ing => ing.Category.GetDescription() == foodGroupDescription))
					).ToList();
			// filter by max calories
			filteredRecipes = filteredRecipes.Where(recipe => recipe.TotalCalories <= maxCalories).ToList();

			return filteredRecipes;
		}

		private void FilterInputsChanged(object sender, RoutedEventArgs e)
		{
			UpdateRecipesListBox();
		}

		private void RecipesListBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			int selectedIndex = RecipesListBox.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < recipes.Count)
			{
				Recipe selectedRecipe = recipes[selectedIndex];
				RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow(selectedRecipe);
				detailsWindow.ShowDialog();
			}
		}

		private void ClearAllFiltersButton_Click(object sender, RoutedEventArgs e)
		{
			FilterIngredientName.Clear();
			FilterFoodGroupComboBox.SelectedIndex = -1;
			FilterMaxCalories.Clear();
			UpdateRecipesListBox();
		}
	}
}


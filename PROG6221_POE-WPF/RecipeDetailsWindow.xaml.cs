using System;
using System.Windows;
using Types.Recipe;

namespace RecipeApp
{
	public partial class RecipeDetailsWindow : Window
	{
		private Recipe _recipe;

		public RecipeDetailsWindow(Recipe recipe)
		{
			InitializeComponent();
			_recipe = recipe;
			DisplayRecipeDetails();
		}

		private void DisplayRecipeDetails()
		{
			RecipeDetailsTextBlock.Text = _recipe.ToString();
		}

		private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
		{
			if (float.TryParse(ScaleFactorTextBox.Text, out float scaleFactor))
			{
				_recipe = _recipe.Scale(scaleFactor);
				DisplayRecipeDetails();
			}
			else
			{
				MessageBox.Show("Invalid scale factor. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}


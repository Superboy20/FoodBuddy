using FoodBuddy.Commands;
using FoodBuddy.Models;
using FoodBuddy.Services;
using FoodBuddy.Stores;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FoodBuddy.ViewModels
{
    public class HomeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public Recipe CurrentRecipe { get; set; }
        public ObservableCollection<Recipe> RecipeCollection { get; set; }
        public ICommand NavigateRecipeCommand { get; set; }
        public ICommand NavigateCreateCommand { get; }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=FoodBuddy;");
        }

        public void LoadData()
        {
            NpgsqlConnection con = GetConnection();
            string query = @"SELECT * FROM recipes";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            var reader = cmd.ExecuteReader();

            var recipes = new ObservableCollection<Recipe>();

            while (reader.Read())
            {
                var recipe = new Recipe()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Ingredients = reader.GetString(reader.GetOrdinal("Ingredients")),
                    Tools = reader.GetString(reader.GetOrdinal("Tools")),
                    Notes = reader.GetString(reader.GetOrdinal("Notes")),
                    Step1 = reader.GetString(reader.GetOrdinal("StepOne")),
                    Step2 = reader.GetString(reader.GetOrdinal("StepTwo")),
                    Step3 = reader.GetString(reader.GetOrdinal("StepThree")),
                    Step4 = reader.GetString(reader.GetOrdinal("StepFour")),
                    Step5 = reader.GetString(reader.GetOrdinal("StepFive")),
                    Step6 = reader.GetString(reader.GetOrdinal("StepSix")),
                };

                CurrentRecipe = recipe;
                recipes.Add(CurrentRecipe);
                RecipeCollection = recipes;
            }
            con.Close();
        }

        public void RecipeData()
        {
            // Maybe I can CHOOSE which recipe to VIEW by ID, e.g., creating new buttons for each list item.
            //for (int i = 0; i < 5; i++)
            //foreach(Recipe in RecipeCollection)
            //{
            //    System.Windows.Controls.Button newBtn = new Button();
            //    newBtn.Content = i.ToString();
            //    newBtn.Name = "Button" + i.ToString();

            //    RecipeCollection.Add(newBtn);
            //}
        }

        public ICommand _recipeButtonCommand;

        public ICommand RecipeButtonCommand
        {
            get { return (_recipeButtonCommand) ?? (_recipeButtonCommand = new RelayCommand(ListItemBtn_Click)); }
        }

        public void ListItemBtn_Click(object obj)
        {
            RecipeData();
            //MessageBox.Show("Hello");
        }

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<RecipeViewModel> recipeNavigationService, NavigationService<CreateViewModel> createNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            NavigateRecipeCommand = new NavigateCommand<RecipeViewModel>(recipeNavigationService);
            NavigateCreateCommand = new NavigateCommand<CreateViewModel>(createNavigationService);
            LoadData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FoodBuddy.Commands;
using FoodBuddy.Models;
using FoodBuddy.Services;
using FoodBuddy.Stores;
using Npgsql;

namespace FoodBuddy.ViewModels
{
    public class RecipeViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public Recipe CurrentRecipe { get; set; }

        public NavigationBarViewModel NavigationBarViewModel { get; }

        // Database Connection

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=FoodBuddy;");
        }

        public void LoadData()
        {
            NpgsqlConnection con = GetConnection();
            string query = @"select * from recipes";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            var reader = cmd.ExecuteReader();

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
            }
            con.Close();
        }

        public RecipeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<HomeViewModel> homeNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);

            LoadData();
        }
    }
}
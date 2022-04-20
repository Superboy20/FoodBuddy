using FoodBuddy.Commands;
using FoodBuddy.Models;
using FoodBuddy.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;
using Npgsql;
using System.Windows;

namespace FoodBuddy.ViewModels
{
    public class CreateViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateHomeCommand { get; }

        public ICommand NavigateSubmitCommand { get; }

        // Add a second command here called "SUBMIT" where it saves the data the user typed in.
        // NavigateHomeCommand will BE the cancel button, where the user will get a confirmation window popping up if clicked

        //private static void InsertRecord()
        //{
        //    using (NpgsqlConnection con = GetConnection())
        //    {
        //        string query = @"insert into public.Recipes(Title, Ingredients, Tools, Notes, StepOne, StepTwo, StepThree, StepFour, StepFive, StepSix)values()";
        //    }
        //}

        //private static void TestConnection()
        //{
        //    using (NpgsqlConnection con = GetConnection())
        //    {
        //        if (con.State == System.Data.ConnectionState.Open)
        //        {
        //            MessageBox.Show("Connected");
        //        }
        //    }
        //}

        public CreateViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<HomeViewModel> homeNavigationService, NavigationService<CreateViewModel> createNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);

            NavigateSubmitCommand = new NavigateCommand<CreateViewModel>(createNavigationService);
        }
    }
}
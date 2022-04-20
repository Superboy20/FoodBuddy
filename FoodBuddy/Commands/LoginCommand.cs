using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FoodBuddy.Services;
using FoodBuddy.Stores;
using FoodBuddy.ViewModels;

namespace FoodBuddy.Commands
{
    class LoginCommand : CommandBase
    {

        private readonly LoginViewModel _viewModel;
        private readonly NavigationService<RecipeViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, NavigationService<RecipeViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }


        



        public override void Execute(object parameter)
        {
            

            _navigationService.Navigate();
        }
    }
}

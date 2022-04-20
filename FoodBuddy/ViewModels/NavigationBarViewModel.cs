using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodBuddy.Commands;
using FoodBuddy.Services;
using FoodBuddy.Stores;

namespace FoodBuddy.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateRecipeCommand { get; }
        public ICommand NavigateCreateCommand { get; }

        public NavigationBarViewModel(
            NavigationService<CreateViewModel> createNavigationService,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<RecipeViewModel> recipeNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateRecipeCommand = new NavigateCommand<RecipeViewModel>(recipeNavigationService);
        }
    }
}
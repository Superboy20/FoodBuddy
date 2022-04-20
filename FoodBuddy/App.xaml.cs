using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FoodBuddy.Services;
using FoodBuddy.Stores;
using FoodBuddy.ViewModels;

namespace FoodBuddy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(
                CreateCreateNavigationService(),
                CreateHomeNavigationService(),
                CreateRecipeNavigationService()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<CreateViewModel> CreateCreateNavigationService()
        {
            return new NavigationService<CreateViewModel>(
                _navigationStore,
                () => new CreateViewModel(_navigationBarViewModel, CreateHomeNavigationService(), CreateCreateNavigationService()));
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(_navigationBarViewModel, CreateRecipeNavigationService(), CreateCreateNavigationService()));
        }

        private NavigationService<RecipeViewModel> CreateRecipeNavigationService()
        {
            return new NavigationService<RecipeViewModel>(
                _navigationStore,
                () => new RecipeViewModel(_navigationBarViewModel, CreateHomeNavigationService()));
        }
    }
}
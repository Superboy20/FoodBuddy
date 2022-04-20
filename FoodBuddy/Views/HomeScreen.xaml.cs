using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FoodBuddy.Models;
using Npgsql;

namespace FoodBuddy.Views
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=FoodBuddy;");
        }

        //public void ListItemBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        System.Windows.Controls.Button newBtn = new Button();
        //        newBtn.Content = i.ToString();
        //        newBtn.Name = "Button" + i.ToString();

        //        RecipeList.Items.Add(newBtn);
        //    }
        //}
    }
}
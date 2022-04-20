using FoodBuddy.Models;
using FoodBuddy.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Npgsql;
using System.IO;
using System.Drawing;

namespace FoodBuddy.Views
{
    /// <summary>
    /// Interaction logic for CreateScreen.xaml
    /// </summary>
    public partial class CreateScreen : UserControl
    {
        public CreateScreen()
        {
            InitializeComponent();
        }

        private void TitleBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (TitleBox.LineCount >= 2 && e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }

        //public void BrowseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.InitialDirectory = "c:\\Pictures";
        //    dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
        //    dlg.RestoreDirectory = true;

        //    bool? response = dlg.ShowDialog();

        //    if (response == true)
        //    {
        //        string selectedFileName = dlg.FileName;
        //        BitmapImage bitmap = new BitmapImage();
        //        bitmap.BeginInit();
        //        bitmap.UriSource = new Uri(selectedFileName);
        //        bitmap.EndInit();
        //        ImgViewer.Source = bitmap;
        //    }
        //}

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=FoodBuddy;");
        }

        public void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.Title = TitleBox.Text;
            recipe.Step1 = StepBox1.Text;
            recipe.Step2 = StepBox2.Text;
            recipe.Step3 = StepBox3.Text;
            recipe.Step4 = StepBox4.Text;
            recipe.Step5 = StepBox5.Text;
            recipe.Step6 = StepBox6.Text;
            recipe.Ingredients = IngredientBox.Text;
            recipe.Tools = ToolBox.Text;
            recipe.Notes = NoteBox.Text;

            void InsertRecord()
            {
                using (NpgsqlConnection con = GetConnection())
                {
                    string query = @"insert into public.Recipes(Title, Ingredients, Tools, Notes, StepOne, StepTwo, StepThree, StepFour, StepFive, StepSix)values(@Title, @Ingredients, @Tools, @Notes, @StepOne, @StepTwo, @StepThree, @StepFour, @StepFive, @StepSix)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", recipe.Title);
                    cmd.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                    cmd.Parameters.AddWithValue("@Tools", recipe.Tools);
                    cmd.Parameters.AddWithValue("@Notes", recipe.Notes);
                    cmd.Parameters.AddWithValue("@StepOne", recipe.Step1);
                    cmd.Parameters.AddWithValue("@StepTwo", recipe.Step2);
                    cmd.Parameters.AddWithValue("@StepThree", recipe.Step3);
                    cmd.Parameters.AddWithValue("@StepFour", recipe.Step4);
                    cmd.Parameters.AddWithValue("@StepFive", recipe.Step5);
                    cmd.Parameters.AddWithValue("@StepSix", recipe.Step6);

                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 1)
                    {
                        MessageBox.Show("Record Inserted");
                    }
                    con.Close();
                }
            }
            InsertRecord();
        }
    }
}
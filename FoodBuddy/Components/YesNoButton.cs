using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodBuddy.Components
{
    public class YesNoButton : Button
    {
        public string Question { get; set; }

        protected override void OnClick()
        {
            if (string.IsNullOrWhiteSpace(Question))
            {
                base.OnClick();
                return;
            }

            var messageBoxResult = MessageBox.Show(Question, "Confirm", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
                base.OnClick();
        }
    }
}
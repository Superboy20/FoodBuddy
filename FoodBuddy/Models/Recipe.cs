using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBuddy.Models
{
    [Table("recipes")]
    public class Recipe : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        private string _title;
        private string _step1;
        private string _step2;
        private string _step3;
        private string _step4;
        private string _step5;
        private string _step6;
        private string _ingredients;
        private string _tools;
        private string _notes;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string Step1
        {
            get { return _step1; }
            set
            {
                if (value != _step1)
                {
                    _step1 = value;
                    NotifyPropertyChanged("Step1");
                }
            }
        }

        public string Step2
        {
            get { return _step2; }
            set
            {
                if (value != _step2)
                {
                    _step2 = value;
                    NotifyPropertyChanged("Step2");
                }
            }
        }

        public string Step3
        {
            get { return _step3; }
            set
            {
                if (value != _step3)
                {
                    _step3 = value;
                    NotifyPropertyChanged("Step3");
                }
            }
        }

        public string Step4
        {
            get { return _step4; }
            set
            {
                if (value != _step4)
                {
                    _step4 = value;
                    NotifyPropertyChanged("Step4");
                }
            }
        }

        public string Step5
        {
            get { return _step5; }
            set
            {
                if (value != _step5)
                {
                    _step5 = value;
                    NotifyPropertyChanged("Step5");
                }
            }
        }

        public string Step6
        {
            get { return _step6; }
            set
            {
                if (value != _step6)
                {
                    _step6 = value;
                    NotifyPropertyChanged("Step6");
                }
            }
        }

        public string Ingredients
        {
            get { return _ingredients; }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
                    NotifyPropertyChanged("Ingredients");
                }
            }
        }

        public string Tools
        {
            get { return _tools; }
            set
            {
                if (value != _tools)
                {
                    _tools = value;
                    NotifyPropertyChanged("Tools");
                }
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                if (value != _notes)
                {
                    _notes = value;
                    NotifyPropertyChanged("Notes");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for PersonEditingPage.xaml
    /// </summary>
    public partial class ViewSpecificPersonPage : Page
    {
        private int personID;
        private string[] recordArray;

        public ViewSpecificPersonPage(int personID, string[] recordArray)
        {
            InitializeComponent();
            this.personID = personID;

            PersonIdTextBox.Text = "P" + personID.ToString("D3");
            this.recordArray = recordArray;
            LastNameTextBox.Text = recordArray[0];
            FirstNameTextBox.Text = recordArray[1];
            MiddleNameTextBox.Text = recordArray[2];
            StudentNumberTextBox.Text = recordArray[3];
            ProgramTextBox.Text = recordArray[4];
            YearTextBox.Text = recordArray[5];

            PersonIdTextBox.IsReadOnly = true;
            LastNameTextBox.IsReadOnly = true;
            FirstNameTextBox.IsReadOnly = true;
            MiddleNameTextBox.IsReadOnly = true;
            StudentNumberTextBox.IsReadOnly = true;
            ProgramTextBox.IsReadOnly = true;
            YearTextBox.IsReadOnly = true;

        }

        private void StudentAddTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            StudentAddPage targetPage = new StudentAddPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void StudentEditTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            StudentEditPage targetPage = new StudentEditPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void StudentDeleteTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            StudentDeletePage targetPage = new StudentDeletePage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }


        private void ViewSpecificPersonBackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Person Edit Page w/o saving any changes
            NavigationService.GoBack();
        }
    }
}

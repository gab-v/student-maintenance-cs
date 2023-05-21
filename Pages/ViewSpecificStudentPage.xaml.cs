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
    public partial class ViewSpecificStudentPage : Page
    {
        private int personSN;
        private string[] recordArray;

        public ViewSpecificStudentPage(int personSN, string[] recordArray)
        {
            InitializeComponent();
            this.personSN = personSN;

            StudentNumberTextBox.Text = "S" + personSN.ToString("D3");

            this.recordArray = recordArray;
            PersonIdTextBox.Text = recordArray[0];
            LastNameTextBox.Text = recordArray[1];
            FirstNameTextBox.Text = recordArray[2];
            MiddleNameTextBox.Text = recordArray[3];
            
            ProgramTextBox.Text = recordArray[5];
            YearTextBox.Text = recordArray[6];

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



        private void ViewSpecificStudentBackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Person Edit Page w/o saving any changes
            NavigationService.GoBack();
        }
    }
}

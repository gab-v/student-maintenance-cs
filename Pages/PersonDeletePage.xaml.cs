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
using System.IO;

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonDeletePage : Page
    {
        public PersonDeletePage()
        {
            InitializeComponent();
        }

        private void PersonAddTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonAddPage targetPage = new PersonAddPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }


        private void PersonEditTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonEditPage targetPage = new PersonEditPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void PersonDeleteTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonDeletePage targetPage = new PersonDeletePage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void PersonDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string personIdToDelete = PersonIdTextBox.Text.Trim();

            // Check if the file exists and contains the person ID for us to delete
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";
            if (File.Exists(filePath))
            {
                bool foundPerson = false;
                List<string> linesToKeep = new List<string>();
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length > 0 && parts[0] == personIdToDelete)
                    {
                        foundPerson = true;
                    }
                    else
                    {
                        linesToKeep.Add(line);
                    }
                }

                if (foundPerson)
                {
                    // Write the lines that are not being deleted back to the file
                    File.WriteAllLines(filePath, linesToKeep);

                    // Show success result of the action made
                    MessageBox.Show("Great! Person data has been deleted successfully.", "HOORAY", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Show error result of the action made
                    MessageBox.Show($"Hey, Buddy. I couldn't found the person you want to delete.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Show error result of the action made
                MessageBox.Show("Apologies, mate. No records found.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Clear the text box
            PersonIdTextBox.Text = "";
        }

    }

}

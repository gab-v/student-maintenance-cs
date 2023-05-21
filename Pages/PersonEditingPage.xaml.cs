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
    public partial class PersonEditingPage : Page
    {
        private int personID;
        private string[] nameArray;

        public PersonEditingPage(int personID, string[] nameArray)
        {
            InitializeComponent();
            this.personID = personID;

            // Debug: Check int value of personID 
            Debug.WriteLine("personID in constructor: " + personID);

            this.nameArray = nameArray;
            LastNameTextBox.Text = nameArray[0];
            FirstNameTextBox.Text = nameArray[1];
            MiddleNameTextBox.Text = nameArray[2];
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

        private void PersonUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the updated data for the person
            nameArray[0] = LastNameTextBox.Text;
            nameArray[1] = FirstNameTextBox.Text;
            nameArray[2] = MiddleNameTextBox.Text;

            // Debug: Check int value of personID
            Debug.WriteLine("personID in UpdateButton_Click: " + personID);

            // Update the data for the person in the file
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";
            string[] lines = File.ReadAllLines(filePath);
            int lineIndex = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');
                if (fields.Length > 0)
                {
                    string id = fields[0].TrimStart('0'); // remove leading zeroes from id
                    if (id == "P" + personID.ToString("D3"))
                    {
                        lineIndex = i;
                        break;
                    }
                }
            }

            if (lineIndex != -1)
            {
                lines[lineIndex] = "P" + personID.ToString("D3") + "\t" + nameArray[0] + "\t" + nameArray[1] + "\t" + nameArray[2];
                File.WriteAllLines(filePath, lines);

                // Show success result of action made
                MessageBox.Show("Sheeeesh, person data has been updated successfully.", "HOORAY", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate back to the MainPage
                NavigationService.GoBack();
            
            }
            else
            {
                // Show error result of action made
                MessageBox.Show("Sad, person data not found.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void PersonCancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Person Edit Page w/o saving any changes
            NavigationService.GoBack();
        }
    }
}

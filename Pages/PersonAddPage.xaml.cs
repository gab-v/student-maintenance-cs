using System;
using System.Collections.Generic;
using System.IO;
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

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for PersonAddPage.xaml
    /// </summary>
    public partial class PersonAddPage : Page
    {
        public PersonAddPage()
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

        // Store last ID number
        private int lastID;

        private void PersonAddButton_Click(object sender, RoutedEventArgs e)
        {
            string[] nameArray = new string[3];
            nameArray[0] = LastNameTextBox.Text;
            nameArray[1] = FirstNameTextBox.Text;
            nameArray[2] = MiddleNameTextBox.Text;

            // Write the nameArray to a file
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            // Check if file exists and read the last ID number
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string lastLine = File.ReadLines(filePath).LastOrDefault();
                    if (lastLine != null)
                    {
                        string[] lastLineArray = lastLine.Split('\t');
                        lastID = int.Parse(lastLineArray[0].Substring(1)) + 1;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Generate a new ID number and write it to the file
                string personId = "P" + lastID.ToString("D3");
                writer.Write(personId);
                writer.Write("\t"); // use tab as separator

                // Write the data for the person
                writer.Write(LastNameTextBox.Text);
                writer.Write("\t"); // use tab as separator
                writer.Write(FirstNameTextBox.Text);
                writer.Write("\t"); // use tab as separator
                writer.Write(MiddleNameTextBox.Text);

                // Move to the next line for the next person
                writer.WriteLine();

                // Clear the text boxes
                LastNameTextBox.Text = "";
                FirstNameTextBox.Text = "";
                MiddleNameTextBox.Text = "";

                // Show success result of the action made
                MessageBox.Show($"You guess it right! Person {personId} has been added successfully.", "HOORAY", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

    }

}


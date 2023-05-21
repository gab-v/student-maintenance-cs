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
    public partial class StudentEditingPage : Page
    {
        private int personID;
        private string[] recordArray;

        public StudentEditingPage(int personID, string[] recordArray)
        {
            InitializeComponent();
            this.personID = personID;

            // Debug: Check int value of personID 
            Debug.WriteLine("personID in constructor: " + personID);

            this.recordArray = recordArray;
            LastNameTextBox.Text = recordArray[0];
            FirstNameTextBox.Text = recordArray[1];
            MiddleNameTextBox.Text = recordArray[2];
            StudentNumberTextBox.Text = recordArray[3];
            ProgramTextBox.Text = recordArray[4];
            YearTextBox.Text = recordArray[5];
        }

        private void StudentAddTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonAddPage targetPage = new PersonAddPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void StudentEditTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonEditPage targetPage = new PersonEditPage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void StudentDeleteTab_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the target page
            PersonDeletePage targetPage = new PersonDeletePage();

            // Navigate to the target page
            this.NavigationService.Navigate(targetPage);
        }

        private void StudentEditingUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the updated data for the person
            recordArray[0] = LastNameTextBox.Text;
            recordArray[1] = FirstNameTextBox.Text;
            recordArray[2] = MiddleNameTextBox.Text;
            recordArray[3] = StudentNumberTextBox.Text;
            recordArray[4] = ProgramTextBox.Text;
            recordArray[5] = YearTextBox.Text;

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
                lines[lineIndex] = "P" + personID.ToString("D3") + "\t" + recordArray[0] + "\t" + recordArray[1] + "\t" + recordArray[2] + "\t" + recordArray[3] + "\t" + recordArray[4] + "\t" + recordArray[5];
                File.WriteAllLines(filePath, lines);

                // Show success result of action made
                MessageBox.Show("Sweeeet! Person data has been updated successfully.", "HOORAY", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate back to the MainPage
                NavigationService.GoBack();
            
            }
            else
            {
                // Show error result of action made
                MessageBox.Show("Person data not found, buddy.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void StudentEditingCancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Person Edit Page w/o saving any changes
            NavigationService.GoBack();
        }
    }
}

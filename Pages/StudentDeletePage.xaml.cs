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
    public partial class StudentDeletePage : Page
    {

        private int personID;
        private string[] recordArray;

        public StudentDeletePage()
        {
            InitializeComponent();
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

        // Constructor for the person class
        public class Person
        {
            public string ID { get; set; }


            public Person(string id, string firstName, string lastName, int age)
            {
                ID = id;
          
            }

            // Static method to validate ID of a person
            public static bool ValidateID(string id)
            {
                if (id.Length != 4 || id[0] != 'P')
                {
                    return false;
                }

                // CHeck if ID contains only digits after first char
                for (int i = 1; i < id.Length; i++)
                {
                    if (!Char.IsDigit(id[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }


        // Event handler for searching person ID
        private void StudentDeleteButton_Click(object sender, RoutedEventArgs e)
        {

            string id = PersonIdTextBox.Text.Trim();
            // Checks if entered ID is in the correct format 'PXXX' where X is a digit
            if (!Person.ValidateID(id))
            {
                // Show error message 
                MessageBox.Show("Invalid ID format. Please enter a valid ID in the format 'PXXX' where X is a digit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            // Read all lines from the file
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Find the person record with the given ID
            bool personExists = false;
            bool studentDontExist = false;
            int lineIndex = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');
                if (fields[0] == id)
                {
                    personExists = true;
                    lineIndex = i;
                    
                    if (fields.Length < 5)
                    {
                        studentDontExist = true;
                    }

                }
            }

            if (personExists)
            {

                if (studentDontExist)
                {
                    // Show error result
                    MessageBox.Show($"Sad, Person {id} is not yet a student. Register first.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {


                    // Remove the "StudentNumber", "Program", and "Year" fields from the person record
                    string[] fields = lines[lineIndex].Split('\t');
                    fields[4] = "";
                    fields[5] = "";
                    fields[6] = "";


                    // Update the file with the deleted person record
                    lines[lineIndex] = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3];
      
        
                    System.IO.File.WriteAllLines(filePath, lines);

                    // Show success message
                    MessageBox.Show("Student data has been deleted successfully.", "HOORAY!", MessageBoxButton.OK, MessageBoxImage.Information);

                    PersonIdTextBox.Text = "";

                }
            }
            else
            {
                // Show error message
                MessageBox.Show("Person data not found.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }







    }

}


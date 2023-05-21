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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class StudentAddPage : Page
    {


        public StudentAddPage()
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


        internal class Person
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
        private void StudentSearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if entered ID is in the correct format 'PXXX' where X is a digit
            string id = PersonIdTextBox.Text.Trim();
            if (!Person.ValidateID(id))
            {
                // SHow error result 
                MessageBox.Show("Invalid ID format. Please enter a valid ID in the format 'PXXX' where X is a digit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            string[] lines = System.IO.File.ReadAllLines(filePath);
            bool personExists = false;
            bool studentDontExist = false;
            string[] recordArray = new string[7];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');
                if (fields[0] == id)
                {
                    personExists = true;
                    recordArray[0] = fields.Length > 1 ? fields[1] : "";
                    recordArray[1] = fields.Length > 2 ? fields[2] : "";
                    recordArray[2] = fields.Length > 3 ? fields[3] : "";


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
                    // Navigates to editing page
                    NavigationService.Navigate(new StudentAddingPage(Convert.ToInt32(id.Substring(1)), recordArray));
                }

                else
                {

                    // Show error result
                    MessageBox.Show($"Oh, Person {id} is already a student.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                // Show error result
                MessageBox.Show($"Oh noes, Person {id} does not exist.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // CLear the text box
            PersonIdTextBox.Text = "";
        }

    }

}









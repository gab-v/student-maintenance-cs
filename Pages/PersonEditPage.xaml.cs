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

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonEditPage : Page
    {

        private string[] nameArray;
        private int personID;

        public PersonEditPage()
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

        // Constructor for the person class
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
        private void PersonEditButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if entered ID is in the correct format 'PXXX' where X is a digit
            string id = PersonIdTextBox.Text.Trim();
            if (!Person.ValidateID(id))
            {
                // SHow error result 
                MessageBox.Show("Oh no! Invalid ID format. Please enter a valid ID in the format 'PXXX' where X is a digit. Got it?", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";
 
            string[] lines = System.IO.File.ReadAllLines(filePath);
            bool personExists = false;
            string[] nameArray = new string[3];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');
                if (fields[0] == id)
                {
                    personExists = true;
                    nameArray[0] = fields[1];
                    nameArray[1] = fields[2];
                    nameArray[2] = fields[3];
                    break;
                }
            }

            if (personExists)
            {
                // Navigates to editing page
                NavigationService.Navigate(new PersonEditingPage(Convert.ToInt32(id.Substring(1)), nameArray));
            }
            else
            {
                // Show error result
                MessageBox.Show($"Oh no, Person {id} does not exist.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // CLear the text box
            PersonIdTextBox.Text = "";
        }

    }

}









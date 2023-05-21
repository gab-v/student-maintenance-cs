using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ViewSpecificPage.xaml
    /// </summary>
    public partial class ViewSpecificPage : Page
    {
        public ViewSpecificPage()
        {
            InitializeComponent();
        }


        // Constructor for the person class
        public class Person
        {
            public string ID { get; set; }

            public string SN { get; set; }

            public Person(string id, string sn)
            {
                ID = id;
      
                SN = sn;
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

            // Static method to validate SN of a person
            public static bool ValidateSN(string sn)
            {
                if (sn.Length != 4 || sn[0] != 'S')
                {
                    return false;
                }

                // CHeck if SN contains only digits after first char
                for (int i = 1; i < sn.Length; i++)
                {
                    if (!Char.IsDigit(sn[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        // Event handler for searching person ID
        private void ViewSpecificPersonIdButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if entered ID is in the correct format 'PXXX' where X is a digit
            string id = PersonIdTextBox.Text.Trim();
            if (!Person.ValidateID(id))
            {
                // SHow error result 
                MessageBox.Show("Nahh, that was an invalid Student Number format. Please enter a valid ID in the format 'PXXX' where X is a digit.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            string[] lines = System.IO.File.ReadAllLines(filePath);
            bool personExists = false;
            string[] recordArray = new string[6];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');
                if (fields[0] == id)
                {
                    personExists = true;
                    recordArray[0] = fields.Length > 1 ? fields[1] : "";
                    recordArray[1] = fields.Length > 2 ? fields[2] : "";
                    recordArray[2] = fields.Length > 3 ? fields[3] : "";
                    recordArray[3] = fields.Length > 4 ? fields[4] : "";
                    recordArray[4] = fields.Length > 5 ? fields[5] : "";
                    recordArray[5] = fields.Length > 6 ? fields[6] : "";
                    break;
                }
            }

            if (personExists)
            {
                // Navigates to editing page
                NavigationService.Navigate(new ViewSpecificPersonPage(Convert.ToInt32(id.Substring(1)), recordArray));
            }
            else
            {
                // Show error result
                MessageBox.Show($"Sorry, Person {id} does not exist", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // CLear the text box
            PersonIdTextBox.Text = "";
        }


        private void ViewSpecificStudentNumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if entered studnet number is in the correct format 'SXXX' where X is a digit
            string sn = StudentNumberTextBox.Text.Trim();
            if (!Person.ValidateSN(sn))
            {
                // SHow error result 
                MessageBox.Show("Nahh, that was an invalid Student Number format. Please enter a valid Student Number in the format 'SXXX' where X is a digit.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            string[] lines = System.IO.File.ReadAllLines(filePath);
            bool personExists = false;
            string[] recordArray = new string[7];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split('\t');

                Debug.WriteLine(sn);

                if (fields.Length >= 5 && fields[4] == sn)
                {
                    personExists = true;
                    recordArray[0] = fields[0];
                    recordArray[1] = fields[1];
                    recordArray[2] = fields[2];
                    recordArray[3] = fields[3];
                    recordArray[5] = fields[5];
                    recordArray[6] = fields[6];
                    break;
                }
            }


            if (personExists)
            {
                // Navigates to editing page
                NavigationService.Navigate(new ViewSpecificStudentPage(Convert.ToInt32(sn.Substring(1)), recordArray));
            }
            else
            {
                // Show error result
                MessageBox.Show($"Sorry, Person {sn} does not exist.", "AWTS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // CLear the text box
            StudentNumberTextBox.Text = "";
        }



    }
}

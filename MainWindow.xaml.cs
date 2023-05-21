using CPE106_FOPI01_VARGAS_MOD1_QUIZ;
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
using System.Windows.Shapes;
using System.IO;

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            navframe.Source = new Uri("/Pages/ViewAllPage.xaml", UriKind.Relative);
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selected = sidebar.SelectedItem as NavButton;

            navframe.Navigate(selected.Navlink);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all records", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(string.Empty); // write an empty string to clear the file
                }
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Close the application
                Application.Current.Shutdown();
            }
        }

        public class Person
        {
            public string ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            public Person(string id, string firstName, string lastName, int age)
            {
                ID = id;
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }

            public static bool ValidateID(string id)
            {
                if (id.Length != 4 || id[0] != 'P')
                {
                    return false;
                }

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






    }
}

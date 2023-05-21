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
using System.Data;

namespace CPE106_FOPI01_VARGAS_MOD1_QUIZ.Pages
{
    /// <summary>
    /// Interaction logic for ViewAllPage.xaml
    /// </summary>
    public partial class ViewAllPage : Page
    {
        public ViewAllPage()
        {
            InitializeComponent();
        }

        private void ViewAllButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";

            // Read the file into an array of strings
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Create a Data Table with the necessary columns
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Person ID", typeof(string));
            dataTable.Columns.Add("Last Name", typeof(string));
            dataTable.Columns.Add("First Name", typeof(string));
            dataTable.Columns.Add("Middle Name", typeof(string));
            dataTable.Columns.Add("Student Number", typeof(string));
            dataTable.Columns.Add("Program", typeof(string));
            dataTable.Columns.Add("Year", typeof(string));

            // Fill the Data Table with the data from the .txt file
            foreach (string line in lines)
            {
                string[] record = line.Split('\t');
                dataTable.Rows.Add(record);
            }

            // Set the ItemsSource of the DataGrid to the DataTable
            ViewAllDataGrid.ItemsSource = dataTable.DefaultView;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lab2_3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ObservableCollection<Person> _people;

        public Window1(ObservableCollection<Person> people)
        {
            InitializeComponent();
            _people = people;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtYearOfBirth.Text) ||
                string.IsNullOrWhiteSpace(txtCityOfResidence.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtYearOfBirth.Text, out int year))
            {
                MessageBox.Show("Year of Birth must be a valid number.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Year of Birth must be between 1900 and the current year.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                _people.Add(new Person(txtFirstName.Text, txtLastName.Text, year, txtCityOfResidence.Text));
                MessageBox.Show("Person added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                txtFirstName.Clear();
                txtLastName.Clear();
                txtYearOfBirth.Clear();
                txtCityOfResidence.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

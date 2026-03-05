using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab2_3
{
    /// <summary>
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        private Person _toEdit;
        public Person Result => _toEdit;

        public Modal()
        {
            InitializeComponent();
            _toEdit = new Person("", "", 0, "");
        }

        public Modal(Person toEdit)
        {
            InitializeComponent();
            _toEdit = toEdit;

            txtFirstNameModal.Text = toEdit.FirstName;
            txtLastNameModal.Text = toEdit.LastName;
            txtYearOfBirthModal.Text = toEdit.YearOfBirth.ToString();
            txtCityOfResidenceModal.Text = toEdit.City;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstNameModal.Text) ||
                string.IsNullOrWhiteSpace(txtLastNameModal.Text) ||
                string.IsNullOrWhiteSpace(txtYearOfBirthModal.Text) ||
                string.IsNullOrWhiteSpace(txtCityOfResidenceModal.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtYearOfBirthModal.Text, out int year))
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
                _toEdit.FirstName = txtFirstNameModal.Text;
                _toEdit.LastName = txtLastNameModal.Text;
                _toEdit.YearOfBirth = year;
                _toEdit.City = txtCityOfResidenceModal.Text;
                this.DialogResult = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

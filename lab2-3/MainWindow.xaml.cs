using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace lab2_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> People { set; get; }

        public MainWindow()
        {

            InitializeComponent();
            People = new ObservableCollection<Person>
            {
                new Person("John", "Smith", 1998, "London"),
                new Person("Anna", "Brown", 2000, "Paris"),
                new Person("Michael", "Johnson", 1995, "New York"),
                new Person("Emily", "Davis", 1999, "Tokyo"),
                new Person("David", "Wilson", 1997, "Sydney")
            };

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 modeless = new Window1(People);
            modeless.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Modal dialog = new Modal();

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                People.Add(dialog.Result);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listViewPeople.SelectedItem != null)
            {
                Person selectedPerson = listViewPeople.SelectedItem as Person;

                if (selectedPerson != null)
                {
                    Modal dialog = new Modal(selectedPerson);
                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        listViewPeople.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select item to edit", "Nothing selected",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        } 
    }
}
// to test commit in another user 
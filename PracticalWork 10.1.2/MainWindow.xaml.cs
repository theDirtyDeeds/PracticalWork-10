using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalWork_10._1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client _client;
        public MainWindow()
        {
            InitializeComponent();
            Client _client = new Client("Иванов", "Иван", "Иванович", "1234567890", "1234", "567890");
            LoadClientInfo();
        }
        private void LoadClientInfo()
        {
            LastNameTextBox.Text = _client.LastName;
            FirstNameTextBox.Text = _client.FirstName;
            MiddleNameTextBox.Text = _client.MiddleName;
            PhoneNumberTextBox.Text = _client.PhoneNumber;
            PassportSeriesTextBox.Text = _client.PassportSeries;
            PassportNumberTextBox.Text = _client.PassportNumber;
            UpdateModificationLog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _client.UpdateClientData("lastname", LastNameTextBox.Text);
            _client.UpdateClientData("firstname", FirstNameTextBox.Text);
            _client.UpdateClientData("middlename", MiddleNameTextBox.Text);
            _client.UpdateClientData("phonenumber", PhoneNumberTextBox.Text);
            _client.UpdateClientData("passportseries", PassportSeriesTextBox.Text);
            _client.UpdateClientData("passportnumber", PassportNumberTextBox.Text);
            UpdateModificationLog();
            MessageBox.Show("Данные клиента обновлены.");
        }

        private void UpdateModificationLog()
        {
            ModificationLogListBox.Items.Clear();
            foreach (var log in _client.ModificationLogs)
            {
                ModificationLogListBox.Items.Add($"{log.Timestamp}: Изменено {log.PropertyName} с '{log.OldValue}' на '{log.NewValue}'");
            }
        }
    }
}
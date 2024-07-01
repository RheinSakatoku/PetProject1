﻿using System;
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

namespace WpfLabwork1
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Client _currentClient = new Client();
        public AddEditPage(Client selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
            {
                _currentClient = selectedClient;
                AddEditTextBlock.Text = "Редактирование клиента";
                IDTextBox.IsEnabled = false;
            }
            else 
            {
                AddEditTextBlock.Text = "Добавление клиента";
                IDTextBox.Visibility = Visibility.Hidden;
                IDTextBlock.Visibility = Visibility.Hidden;
            }
            DataContext = _currentClient;
            GenderComboBox.ItemsSource = Laba6Entities.GetContext().Gender.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.LastName))
                errors.AppendLine("Не указана фамилия");
            if (string.IsNullOrWhiteSpace(_currentClient.FirstName))
                errors.AppendLine("Не указано имя");
            if (_currentClient.Gender == null)
                errors.AppendLine("Не выбан пол");
            if (_currentClient.Phone == null)
                errors.AppendLine("Не указан контактный телефон");
            if (_currentClient.Email == null)
                errors.AppendLine("Не указан контактный Email");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentClient.ID == 0)
            {
                Laba6Entities.GetContext().Client.Add(_currentClient);
            }
            try 
            {
                Laba6Entities.GetContext().SaveChanges();
                MessageBox.Show("Добавлен!");
                NavigationService.GoBack();
            }
            catch (Exception ex) 
            {
            MessageBox.Show(ex.Message);
            }

        }
    }
}

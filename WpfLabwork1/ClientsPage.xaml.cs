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

namespace WpfLabwork1
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();

            List<Gender> allGender = Laba6Entities.GetContext().Gender.ToList();

            allGender.Insert(0, new Gender 
            { 
                Name = "Все типы"
            });
            FiltrCB.ItemsSource = allGender;
            FiltrCB.DisplayMemberPath = "Name";
            FiltrCB.SelectedValuePath = "Code";
            FiltrCB.SelectedIndex = 0;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MainDataGrid.ItemsSource = Laba6Entities.GetContext().Client.ToList();
        }
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данные?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    Laba6Entities.GetContext().Client.Remove(MainDataGrid.SelectedItem as Client);
                    Laba6Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(null));
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(MainDataGrid.SelectedItem as Client));
        }
        private void ProfButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void UpdateClients()
        {
            List<Client> currentClients = Laba6Entities.GetContext().Client.ToList();
            if (SortComboBox != null)
            {
                switch (SortComboBox.SelectedIndex)
                {
                    case 1:
                        {
                            if (Up.IsChecked.Value)
                                currentClients = currentClients.OrderBy(x => x.LastName).ToList();
                            if (Down.IsChecked.Value)
                                currentClients = currentClients.OrderByDescending(x => x.LastName).ToList();
                            break;
                        }
                    case 2:
                        {
                            if (Up.IsChecked.Value)
                                currentClients = currentClients.OrderBy(x => x.RegistrationDate).ToList();
                            if (Down.IsChecked.Value)
                                currentClients = currentClients.OrderByDescending(x => x.RegistrationDate).ToList();
                            break;
                        }
                }
            }
            if (SearchCB != null && SearchTB != null)
            {
                switch (SearchCB.SelectedIndex)
                {
                    case 0:
                        {
                            currentClients = currentClients.Where(x => x.LastName.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
                            break;
                        }
                    case 1:
                        {
                            currentClients = currentClients.Where(x => x.FirstName.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
                            break;
                        }
                    case 2:
                        {
                            currentClients = currentClients.Where(x => x.Patronymic.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
                            break;
                        }
                    case 3:
                        {
                            currentClients = currentClients.Where(x => x.Email.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
                            break;
                        }
                    case 4:
                        {
                            currentClients = currentClients.Where(x => x.Phone.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
                            break;
                        }
                }
            }
            if (FiltrCB != null && FiltrCB.SelectedIndex > 0)
            {
                string selectedGender = Convert.ToString(FiltrCB.SelectedValue);
                currentClients = currentClients.Where(x => x.GenderCode == selectedGender).ToList();
            }

            MainDataGrid.ItemsSource = currentClients.ToList();
            
            if (currentClients.Count == 0)
            {
                MessageBox.Show("Ничего не найдено");
                SearchTB.Text = "";
            }
        }
        private void Filtr_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateClients();
        }
        private void Search_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateClients();
        }
        private void SearchTBC(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }
        private void Sort_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateClients();
        }
        private void UpChecked(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }
        private void DownChecked(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }
    }
}

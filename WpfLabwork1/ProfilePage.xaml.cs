using DocumentFormat.OpenXml.Vml;
using OpenXmlPowerTools;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        List<Client> profilee = Laba6Entities.GetContext().Client.Where(x => x.ID.Equals(Token.token)).ToList();
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = profilee;
            GenderComboBoxprof.ItemsSource = Laba6Entities.GetContext().Gender.ToList();//ne vork
            Disabler();

        }
        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
        private void Disabler() 
        {
            IDTextBoxprof.IsEnabled = false;
            Fam.IsEnabled = false;
            Nam.IsEnabled = false;
            Pat.IsEnabled = false;
            GenderComboBoxprof.IsEnabled = false;
            Bir.IsEnabled = false;
            Ph.IsEnabled = false;
            Em.IsEnabled = false;
            RegDatePickerprof.IsEnabled = false;
        }
    }
}

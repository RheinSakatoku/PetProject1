using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private readonly Laba6Entities db = new Laba6Entities();
        public MainPage()
        {
            InitializeComponent();
            Updater();
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }
        private void Updater()
        {

            NameTextBlock.Text = Convert.ToString(db.Client.Where(x => x.ID.Equals(Token.token))
                .Select(item => item.FirstName).Single()) + " " + Convert.ToString(db.Client.Where(x => x.ID.Equals(Token.token)).Select(item => item.LastName).Single());
            int dttm = DateTime.Now.Hour;
            string ttb = "Доброе утро";
            switch (dttm)
            {
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    ttb = "Доброе утро";
                    break;

                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                     ttb = "Добрый день";
                    break;

                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    ttb = "Добрый вечер";
                    break;

                case 23:
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    ttb = "Доброй ночи";
                    break;
            }
            TimeTextBlock.Text = ttb;
        }
    }
}

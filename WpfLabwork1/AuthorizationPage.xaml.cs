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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        Random _rand = new Random();
        string strCpt = "";
        private readonly Laba6Entities db = new Laba6Entities();
        public string chkr;
        public AuthorizationPage()
        {
            InitializeComponent();
            UpdateCaptcha();
        }
        private void UpdateCaptcha()
        {
            strCpt = "";
            SymPan.Children.Clear();
            NoiseC.Children.Clear();

            GenSym(4);
            GNoise(_rand.Next (10,15));

        }
        private void GenSym (int count) 
        {
            string alph = "qwertyuiopasdfghjklzxcvbnm0123456789";
            for (int i = 0; i< count; i++) 
            {
                string sym = alph.ElementAt(_rand.Next(0, alph.Length)).ToString();
                TextBlock lbl = new TextBlock();

                lbl.Text = sym;
                lbl.FontSize = _rand.Next(20, 50);
                lbl.RenderTransform = new RotateTransform(_rand.Next(-45, 45));
                lbl.Margin = new Thickness(10, 10, 10, 0);

                strCpt += sym;
                SymPan.Children.Add(lbl);
            }
        }
        private void GNoise(int vn)
        {
            for (int i = 0; i < vn; i++) 
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)_rand.Next(50, 150),
                                                                      (byte)_rand.Next(0, 256),
                                                                      (byte)_rand.Next(0, 256),
                                                                      (byte)_rand.Next(0, 256)));
                border.Height = _rand.Next(2, 10);
                border.Width = _rand.Next(20, 100);
                border.RenderTransform = new RotateTransform(_rand.Next(0, 90));

                NoiseC.Children.Add(border);
                Canvas.SetLeft(border, _rand.Next(0, 200));
                Canvas.SetTop(border, _rand.Next(0, 70));

                Ellipse borde = new Ellipse();
                borde.Fill = new SolidColorBrush(Color.FromArgb((byte)_rand.Next(50, 150),
                                                                      (byte)_rand.Next(0, 256),
                                                                      (byte)_rand.Next(0, 256),
                                                                      (byte)_rand.Next(0, 256)));
                borde.Height = _rand.Next(2, 10);
                borde.Width = _rand.Next(20, 100);
                borde.RenderTransform = new RotateTransform(_rand.Next(0, 90));

                NoiseC.Children.Add(borde);
                Canvas.SetLeft(borde, _rand.Next(0, 200));
                Canvas.SetTop(borde, _rand.Next(0, 70));
            }
        }
        private void UpdateCpt_Click (object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (LoginTextBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show("Пустые поля!");
            }
            else if (CptBox.Text != strCpt) 
            {
                MessageBox.Show("Ошибка при вводе капчи");
                UpdateCaptcha();
            }
            else
            {
                chkr = LoginTextBox.Text;
                if (db.Client.Select(item => item.LastName).Contains(LoginTextBox.Text) && db.Client.Where(x => x.LastName == chkr).Select(item => item.Email).Contains(PasswordBox.Text))
                {
                    Token.token = Convert.ToInt32(db.Client.Where(x => x.LastName == chkr).Select(item => item.ID).Single());
                    NavigationService.Navigate(new MainPage());
                }
                else
                {
                    MessageBox.Show("Ошибка логина или пароля!");
                }
            }
        }
    }
}

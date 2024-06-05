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
using TiketConcert.Class;
using TiketConcert.Model;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для authPage.xaml
    /// </summary>
    public partial class authPage 
    {
        public authPage()
        {
            InitializeComponent();
           
        }

        private async void Auth()
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {
                //MessageBox.Show("Поле \"Login\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ErroText.Text = "Пустой Логин";
                return;
            }
            if (string.IsNullOrWhiteSpace(PassBox.Text))
            {
                //MessageBox.Show("Поле \"Password\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ErroText.Text = "Пустой Пароль";
                return;
            }

            AuthUserNow authUserNow = new AuthUserNow();

            authUserNow.identifier = LoginBox.Text;
            authUserNow.password = PassBox.Text;
            AuthUser authUser = new AuthUser();
            
            authUser = await AppData.Context.Authorization(authUserNow);
            
            if (authUser.error == null)
            {
                switch (authUser.IDPosition)
                {
                    case "1":
                        TempData.UserToken = authUser.token;
                        TempData.IdUser=Convert.ToInt32(authUser.IdUser);
                        TempData.IdPosition=authUser.IDPosition;
                        TempData.FirstName =authUser.FirstName;
                        TempData.LastName =authUser.LastName;
                        //MessageBox.Show(TempData.IdUser);
                        NavigationService.Navigate(new Page.TiketView());
                        break;
                    case "2":
                        TempData.UserToken = authUser.token;
                        TempData.IdUser = Convert.ToInt32(authUser.IdUser);
                        TempData.IdPosition = authUser.IDPosition;
                        TempData.FirstName = authUser.FirstName;
                        TempData.LastName = authUser.LastName;
                        //MessageBox.Show(TempData.IdUser);
                        NavigationService.Navigate(new Page.adminPage());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //MessageBox.Show(authUser?.error ?? "Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ErroText.Text = authUser.error;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth();
        }

        private void PageReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page.registPage());
        }

        //private bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private bool IsValidPhoneNumber(string phone)
        //{
        //    return phone.All(char.IsDigit) && phone.Length >= 10 && phone.Length <= 15;
        //}


    }
}

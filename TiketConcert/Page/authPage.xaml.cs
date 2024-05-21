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
            try
            {
                AppData.updateContext();
                AppData.Context.RunAsync().GetAwaiter().GetResult();
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с сервером!" +
                    "\nПожалуйста, запустите сервер заново запустите приложение!",
                    "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private async void Auth()
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {
                MessageBox.Show("Поле \"Login\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(PassBox.Text))
            {
                MessageBox.Show("Поле \"Password\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        TempData.IdUser=authUser.IdUser;
                        TempData.IdPosition=authUser.IDPosition;
                        MessageBox.Show(TempData.IdUser);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show(authUser.error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10 && phone.Length <= 15;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth();
        }
    }
}

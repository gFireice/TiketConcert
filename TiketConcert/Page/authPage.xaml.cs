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

       

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {

                ErroText.Text = "Пустой Логин";
                return;
            }
            if (string.IsNullOrWhiteSpace(PassBox.Text))
            {

                ErroText.Text = "Пустой Пароль";
                return;
            }

            AuthUserNow authUserNow = new AuthUserNow();

            authUserNow.identifier = LoginBox.Text;
            authUserNow.password = PassBox.Text;
            AuthUser authUser = new AuthUser();
            try
            {
                authUser = await AppData.Context.Authorization(authUserNow);

                if (authUser.error == null)
                {
                    TempData.IdUser = Convert.ToInt32(authUser.IdUser);
                    TempData.IdPosition = authUser.IDPosition;
                    TempData.FirstName = authUser.FirstName;
                    TempData.LastName = authUser.LastName;
                    TempData.Email = authUser.Email;
                    TempData.Phone = authUser.Phone;
                    TempData.Birthday = authUser.Birthday;
                    switch (authUser.IDPosition)
                    {
                        case "1":
                            NavigationService.Navigate(new Page.TiketView());
                            break;
                        case "2":


                            NavigationService.Navigate(new Page.adminPage());
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ErroText.Text = authUser.error;
                }
            }
            catch
            {
                MessageBox.Show(authUser?.error ?? "Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PageReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page.registPage());
        }




    }
}

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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TiketConcert.Class;
using TiketConcert.Model;


namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для TiketView.xaml
    /// </summary>
    public partial class TiketView
    {
        public TiketView()
        {
            InitializeComponent();
            NavigationFrame.Content=new Page.ListPosterPage();
            UserNameBlock.Text = $"{TempData.FirstName} {TempData.LastName}";
            NavigateComtrol.MainFrame = this.NavigationFrame;

        }

        private void TextAccount_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform scaleTransform = acc.RenderTransform as ScaleTransform;
            if (scaleTransform.ScaleX == 0)
            {
        
                Storyboard storyboard = (Storyboard)this.Resources["ShowAccStoryboardRightToLeft"];
                storyboard.Begin();
            }
            else
            {

                Storyboard storyboard = (Storyboard)this.Resources["ShowAccStoryboardLeftToRight"];
                storyboard.Begin();

            }
        }

        private void ButtonExith_Click(object sender, RoutedEventArgs e)
        {
            TempData.UserToken = null;
            NavigationService.Navigate(new Page.authPage());
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.HistoryPage());
        }

        private void Paket_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.BasketPage());
        }

        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {

            NavigateComtrol.MainFrame.Navigate(new Page.ListPosterPage());
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.ProfilePage());
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter.TextFilter=TextSearch.Text;
        }
    }
}

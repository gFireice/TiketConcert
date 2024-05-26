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
    /// Логика взаимодействия для ListPosterPage.xaml
    /// </summary>
    public partial class ListPosterPage
    {
        public ListPosterPage()
        {
            InitializeComponent();
            LoadConcertsAsync();
        }

        private async void LoadConcertsAsync()
        {
            List<Model.Concert> concerts = new List<Model.Concert>();
            concerts = await AppData.Context.GetAllConcrt();
            lvConcert.ItemsSource = concerts;
        }

        private void lvConcert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (sender is Grid grid)
            //{
            //    if (grid.DataContext is Concert concert)
            //    {

            //        NavigateComtrol.MainFrame.Navigate(new Page.shopConcertPage(concert));
            //    }
            //}
            if (sender is Grid grid)
            {
                if (grid.DataContext is Concert concert)
                {
                    NavigateComtrol.ViewFrame.Navigate(new Page.shopConcertPage(concert));
                }
            }

        }
    }
}

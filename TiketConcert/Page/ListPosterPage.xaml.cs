using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Filter filter;
        public ListPosterPage()
        {
            InitializeComponent();
            filter = new Filter();
            filter.PropertyChanged += Filter_PropertyChanged;
            LoadConcerts();
        }

        private async void LoadConcerts()
        {
            try
            {
                if (AppData.concerts == null || !AppData.concerts.Any())
                    AppData.concerts = await AppData.Context.GetAllConcrt();

                    if (string.IsNullOrEmpty(Filter.TextFilter))
                    {
                        lvConcert.ItemsSource = AppData.concerts;
                    }else
                        lvConcert.ItemsSource = AppData.concerts
                        .Where(c => c.TitleConcert.ToLower().Contains(Filter.TextFilter.ToLower()))
                        .ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading concerts: {ex.Message}");
            }
        }

        private void Filter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Filter.TextFilter))
            {
                LoadConcerts();
            }
        }


        private void lvConcert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                if (grid.DataContext is Concert concert)
                {
                    NavigateComtrol.MainFrame.Navigate(new Page.shopConcertPage(concert));
                }
            }

        }
    }
}

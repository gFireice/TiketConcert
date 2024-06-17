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

        public ListPosterPage()
        {
            InitializeComponent();


            BoxPlace.ItemsSource = AppData.Place;
            BoxPlace.SelectedIndex = Filter.Place;
            BoxStyle.ItemsSource = AppData.MusicStyle;
            BoxStyle.SelectedIndex=Filter.Style;

            LoadConcerts();
        }

        private async void LoadConcerts()
        {
            
            try
            {
                if (AppData.concerts == null || !AppData.concerts.Any())
                    AppData.concerts = await AppData.Context.GetAllConcrt();
                List<Concert> concerts = AppData.concerts;
                if (!string.IsNullOrEmpty(Filter.TextFilter))
                    concerts = AppData.concerts
                       .Where(c => c.TitleConcert.ToLower().Contains(Filter.TextFilter.ToLower()))
                       .ToList(); 
                if (BoxStyle.SelectedIndex > 0)
                    concerts = concerts.Where(c => c.IDStyleOfMusic.Equals(BoxStyle.SelectedIndex)).ToList();
                if (BoxPlace.SelectedIndex > 0)
                    concerts = concerts.Where(c => c.IDPlace.Equals(BoxPlace.SelectedIndex)).ToList();
                lvConcert.ItemsSource = concerts;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading concerts: {ex.Message}");
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

        private void BoxPlace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter.Place = BoxPlace.SelectedIndex;
            LoadConcerts();
        }

        private void BoxStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            Filter.Style = BoxStyle.SelectedIndex;
            LoadConcerts();
        }

        
    }
}

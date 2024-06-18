using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для adminConcertPage.xaml
    /// </summary>
    public partial class adminConcertPage 
    {
        public adminConcertPage()
        {
            InitializeComponent();
            LoadConcertsAsync();
        }
        private async void LoadConcertsAsync()
        {
            try
            {
                List<Model.Concert> concerts = new List<Model.Concert>();
                AppData.concerts = await AppData.Context.GetAllConcrt();
                concerts = AppData.concerts;
                if (!string.IsNullOrEmpty(Filter.TextFilter))
                    concerts = AppData.concerts
                       .Where(c => c.TitleConcert.ToLower().Contains(Filter.TextFilter.ToLower()))
                       .ToList();
                lvConcert.ItemsSource = concerts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading concerts: {ex.Message}");
            }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            if (sender is Grid grid)
            {
                if (grid.DataContext is Concert concert)
                {
                    NavigateComtrol.MainFrame.Navigate(new Page.adeitConcertPage(concert));
                }
            }

        }

        private void addConcertButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.adeitConcertPage());
        }
    }
}


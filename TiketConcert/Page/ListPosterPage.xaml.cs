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
    /// Логика взаимодействия для ListPosterPage.xaml
    /// </summary>
    public partial class ListPosterPage
    {
        public ListPosterPage()
        {
            InitializeComponent();
            LoadConcerts();
        }

        private async void LoadConcerts()
        {
            try
            {
                if (AppData.concerts == null || !AppData.concerts.Any())
                {
                    AppData.concerts = await AppData.Context.GetAllConcrt();
                }

                if (AppData.concerts != null && AppData.concerts.Any())
                {
                    lvConcert.ItemsSource = AppData.concerts;
                }
                else
                {
                    MessageBox.Show("No concerts available at the moment.");
                }
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
    }
}

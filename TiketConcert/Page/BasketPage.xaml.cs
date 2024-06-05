using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using TiketConcert.Api;
using TiketConcert.Class;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage
    {
        public BasketPage()
        {
            InitializeComponent();
            Filter();
        }

        public void Filter()
        {
            var groupedItems = AppData.basket
                .GroupBy(item => item.TitleConcert)
                .Select(group => new
                {
                    TitleConcert = group.Key,
                    ByteImage = group.First().ByteImage,
                    Quantity = group.Count(),
                    Price = group.First().Price,
                    Total = group.Sum(item => item.Price)
                })
                .ToList();

            lvConcert.ItemsSource = groupedItems;
        }

        private void RemoveConcert_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.DataContext as dynamic;
            if (item != null)
            {
                var concertToRemove = AppData.basket.FirstOrDefault(c => c.TitleConcert == item.TitleConcert);
                if (concertToRemove != null)
                {
                    AppData.basket.Remove(concertToRemove);
                    Filter();
                }
            }
        }

        private async void ButtonPay_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = await AppData.Context.CreateOrder(AppData.basket);

            if (isSuccess)
            {
                MessageBox.Show("Order successfully created!");
                AppData.basket.Clear();
                Filter();
            }
            else
            {
                MessageBox.Show("Failed to create order. Please try again.");
            }
        }
    }
}
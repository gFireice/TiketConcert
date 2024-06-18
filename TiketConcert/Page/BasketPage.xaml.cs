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
using TiketConcert.Model;

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
            LoadBasket();
        }

        public void LoadBasket()
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

            if (!string.IsNullOrEmpty(Filter.TextFilter))
                groupedItems = groupedItems
                   .Where(c => c.TitleConcert.ToLower().Contains(Filter.TextFilter.ToLower()))
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
                    LoadBasket();
                }
            }
        }

        private async void ButtonPay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isSuccess = await AppData.Context.CreateOrder(AppData.basket);

                if (isSuccess)
                {
                    MessageBox.Show("Выполнен");
                    AppData.basket.Clear();
                    LoadBasket();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
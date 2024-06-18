using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiketConcert.Class;
using TiketConcert.Model;
using TiketConcert.Api;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для adeitConcertPage.xaml
    /// </summary>
    public partial class adeitConcertPage
    {
        private bool AddCode;

        public Concert concerts = new Concert();

        public adeitConcertPage()
        {
            InitializeComponent();
            //Concert concert;
            BoxPalace.ItemsSource = AppData.Place;
            BoxOrganization.ItemsSource = AppData.Organization;
            BoxStyle.ItemsSource = AppData.MusicStyle;
            AddCode = true;
        }

        public adeitConcertPage(Concert concert)
        {
           
            concerts=concert;
            AddCode = false;
            InitializeComponent();
            ButtonRemove.Visibility = Visibility.Visible;
            BoxPalace.ItemsSource = AppData.Place;
            BoxOrganization.ItemsSource = AppData.Organization;
            BoxStyle.ItemsSource= AppData.MusicStyle;
            byte[] imageData = AppData.Context.GetImage(concert.Poster);
            if (imageData != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CreateOptions = BitmapCreateOptions.None;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.Rotation = Rotation.Rotate0;
                bitmap.StreamSource = new MemoryStream(imageData);
                bitmap.EndInit();
                ImageSource imageSource = bitmap;
                imageBorder.ImageSource = imageSource;
            }
            
            DescriptionTxt.Text = concert.Description;
            CostTxt.Text = Convert.ToString(concert.Price);
            TitleTxt.Text = concert.TitleConcert;
            BoxOrganization.SelectedIndex = concert.IDOrganization;
            BoxPalace.SelectedIndex = concert.IDPlace;
            BoxStyle.SelectedIndex = concert.IDStyleOfMusic;
            BoxDate.Text= Convert.ToString(concert.StartDate);
            BoxStock.Text = Convert.ToString(concert.InStock);
            BoxTime.Text = Convert.ToString(concert.DurationInHours);

        }
        
        private  void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.adminConcertPage());
        }

        private async void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isSuccess = false;
                if (checkFormat() == true)
                {
                    switch (AddCode)
                    {

                        case true:
                            concerts.DurationInHours = Convert.ToDecimal(BoxTime.Text);
                            concerts.StartDate = Convert.ToDateTime(BoxDate.Text);
                            concerts.TitleConcert = TitleTxt.Text;
                            concerts.Description = DescriptionTxt.Text;
                            concerts.Price = Convert.ToDecimal(CostTxt.Text);
                            concerts.IDPlace = BoxPalace.SelectedIndex;
                            concerts.IDStyleOfMusic = BoxStyle.SelectedIndex;
                            concerts.IDOrganization = BoxOrganization.SelectedIndex;
                            concerts.InStock = Convert.ToInt32(BoxStock.Text);
                            isSuccess = await AppData.Context.AddConcert(concerts);
                            break;
                        case false:
                            concerts.DurationInHours = Convert.ToDecimal(BoxTime.Text);
                            concerts.StartDate = Convert.ToDateTime(BoxDate.Text);
                            concerts.TitleConcert = TitleTxt.Text;
                            concerts.Description = DescriptionTxt.Text;
                            concerts.Price = Convert.ToDecimal(CostTxt.Text);
                            concerts.IDPlace = BoxPalace.SelectedIndex;
                            concerts.IDStyleOfMusic = BoxStyle.SelectedIndex;
                            concerts.IDOrganization = BoxOrganization.SelectedIndex;
                            concerts.InStock = Convert.ToInt32(BoxStock.Text);
                            isSuccess = await AppData.Context.UpdateConcert(concerts.IDConcert, concerts);
                            break;
                    }
                    if (isSuccess)
                    {
                        System.Windows.MessageBox.Show("Выполнено");
                        AppData.basket.Clear();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else System.Windows.MessageBox.Show( "Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка не изменения/добавления: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool checkFormat()
        {
            bool code = true;
            if(string.IsNullOrEmpty(TitleTxt.Text) || string.IsNullOrEmpty(BoxTime.Text) || 
                string.IsNullOrEmpty(CostTxt.Text) || string.IsNullOrEmpty(DescriptionTxt.Text) ||
                string.IsNullOrEmpty(BoxStock.Text) || string.IsNullOrEmpty(BoxDate.Text) ||
                BoxPalace.SelectedIndex ==0 || BoxStyle.SelectedIndex==0 || BoxOrganization.SelectedIndex==0 
                ) code = false;
            return code;
        }

        private void BoxTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Удлить?", "Удлить", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                PerformDeleteOperation();
                NavigateComtrol.MainFrame.Navigate(new Page.adminConcertPage());
            }
        }

        private async void PerformDeleteOperation()
        {
            try
            {
                bool isDeleted = await AppData.Context.DeleteConcert(concerts.IDConcert);
                if (isDeleted)
                {
                    System.Windows.MessageBox.Show("Удаление выполнено", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    System.Windows.MessageBox.Show("Ошибка не удалено1", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка не удалено: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

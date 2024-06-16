using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для shopConcertPage.xaml
    /// </summary>
    public partial class shopConcertPage
    {

        Model.Concert concerts = new Model.Concert();

        public shopConcertPage(Concert concert)
        {
            InitializeComponent();
            byte[] imageData = AppData.Context.GetImage(concert.Poster);

            concerts = concert;

            if (imageData != null)
            {
                try
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
                catch {
                    MessageBox.Show("Ошибка изображения");
                }
                
            }
            
            DescriptionTxt.Text = concert.Description;
            CostTxt.Text =$"Цена: {Convert.ToString(concert.Price)}р";
            TitleTxt.Text = $"Цена: {concert.TitleConcert}";
            TimeTxt.Text = $"Продолжительность: {Convert.ToString(concert.DurationInHours)}";
            DateTxt.Text= $"Дата: {Convert.ToString(concert.StartDate)}";
            PlaceTxt.Text = $"Место: {AppData.Place[concert.IDPlace]}";
            OrgTxt.Text = $"Организация: {AppData.Organization[concert.IDOrganization]}";
            StyleTxt.Text = $"Стиль Музыки: {AppData.MusicStyle[concert.IDStyleOfMusic]}";

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
           NavigateComtrol.MainFrame.Navigate(new Page.ListPosterPage());
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            AppData.basket.Add(concerts);
        }
    }
}

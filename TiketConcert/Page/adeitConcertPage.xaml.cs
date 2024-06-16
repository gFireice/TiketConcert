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
            ForBox();
            AddCode = true;
        }

        public adeitConcertPage(Concert concert)
        {
            concerts=concert;
            AddCode = false;
            InitializeComponent();
            ForBox();
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
            BoxOrganization.SelectedIndex = concert.IDOrganization - 1;
            BoxPalace.SelectedIndex = concert.IDPlace-1;
            BoxStyle.SelectedIndex = concert.IDStyleOfMusic-1;
            BoxDate.Text= Convert.ToString(concert.StartDate);
            BoxStock.Text = Convert.ToString(concert.InStock);
            BoxTime.Text = Convert.ToString(concert.DurationInHours);

        }
        public void ForBox()
        {
            foreach (string address in AppData.Place)
            {
                BoxPalace.Items.Add(address);
            }
            foreach (string address in AppData.Organization)
            {
                BoxOrganization.Items.Add(address);
            }
            foreach (string address in AppData.MusicStyle)
            {
                BoxStyle.Items.Add(address);
            }
        }
        private  void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.MainFrame.Navigate(new Page.adminConcertPage());
        }

        private async void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess=false;
            switch (AddCode)
            {
                  
                case true:
                    concerts.DurationInHours =Convert.ToDecimal(BoxTime.Text);
                    concerts.StartDate=Convert.ToDateTime(BoxDate.Text);
                    concerts.TitleConcert = TitleTxt.Text;
                    concerts.Description=DescriptionTxt.Text;
                    concerts.Price=Convert.ToDecimal(CostTxt.Text);
                    concerts.IDPlace = BoxPalace.SelectedIndex+1;
                    concerts.IDStyleOfMusic=BoxStyle.SelectedIndex + 1;
                    concerts.IDOrganization = BoxOrganization.SelectedIndex + 1;
                    concerts.InStock=Convert.ToInt32(BoxStock.Text);
                    isSuccess = await AppData.Context.AddConcert(concerts);
                break;
                case false:
                    concerts.DurationInHours = Convert.ToDecimal(BoxTime.Text);
                    concerts.StartDate = Convert.ToDateTime(BoxDate.Text);
                    concerts.TitleConcert = TitleTxt.Text;
                    concerts.Description = DescriptionTxt.Text;
                    concerts.Price = Convert.ToDecimal(CostTxt.Text);
                    concerts.IDPlace = BoxPalace.SelectedIndex + 1;
                    concerts.IDStyleOfMusic = BoxStyle.SelectedIndex + 1;
                    concerts.IDOrganization = BoxOrganization.SelectedIndex + 1;
                    concerts.InStock = Convert.ToInt32(BoxStock.Text);
                    isSuccess = await AppData.Context.UpdateConcert(concerts.IDConcert,concerts);
                    break;
            }
            if (isSuccess)
            {
                System.Windows.MessageBox.Show("Order successfully created!");
                AppData.basket.Clear();
            }
            else
            {
                System.Windows.MessageBox.Show("Failed to create order. Please try again.");
            }
        }
    }
}

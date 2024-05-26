﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для shopConcertPage.xaml
    /// </summary>
    public partial class shopConcertPage
    {
        public shopConcertPage(Concert concert)
        {
            InitializeComponent();
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
            CostTxt.Text =$"Цена:{Convert.ToString(concert.Price)}р";
            TitleTxt.Text = concert.TitleConcert;
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigateComtrol.ViewFrame.Navigate(null);
        }
    }
}

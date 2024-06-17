using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiketConcert.Class;
using TiketConcert.Model;

namespace TiketConcert.Page
{

    public partial class adminPage 
    {
        public adminPage()
        {
            InitializeComponent();
            NavigationFrame.Content = new Page.adminConcertPage();
            NavigateComtrol.MainFrame = this.NavigationFrame;

        }
       
        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter.TextFilter = TextSearch.Text;
            NavigateComtrol.MainFrame.Navigate(new Page.adminConcertPage());

        }
    }
}

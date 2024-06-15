using System;
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

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage
    { 
        public HistoryPage()
        {
            InitializeComponent();
            
            Filter();
        }

        public async void Filter()
        {
            AppData.Orders = await AppData.Context.GetOrderById(TempData.IdUser);
 
            var groupedItems = AppData.Orders;
              

            lvConcert.ItemsSource = groupedItems;
        }
    }
}

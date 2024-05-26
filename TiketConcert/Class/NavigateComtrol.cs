using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TiketConcert.Class
{
    public class NavigateComtrol
    {
        public static Frame MainFrame { get; set; } = new Frame();

        public static Frame ViewFrame { get; set; } = new Frame();

        public static Frame EditFrame { get; set; } = new Frame();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketConcert.Api;

namespace TiketConcert.Class
{
    public class AppData
    {
        public static Api.ApiControler Context { get; set; } = new Api.ApiControler();
        public static void updateContext()
        {
            Context = new Api.ApiControler();
        }

        public static List<Model.Concert> basket { get; set; } = new List<Model.Concert>();

        public static List<Model.Concert> concerts { get; set; } = new List<Model.Concert>();

        public static List<Model.Orderer> Orders { get; set; } = new List<Model.Orderer>();
    }
}

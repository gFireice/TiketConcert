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
    }
}

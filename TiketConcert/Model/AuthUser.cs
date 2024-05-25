using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Model
{
    public class AuthUser
    {
        public string token { get; set; }

        public string error { get; set; } = null;

        public string IdUser { get; set; }

        public string IDPosition { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    }
}

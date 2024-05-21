using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Model
{
    public class User
    {
        public int IDClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IDGender { get; set; }
        public bool IsDeleted { get; set; }
        public int IDPosition { get; set; }
        public string LoginC { get; set; }

        public string PasswordC { get; set; }
    }
}

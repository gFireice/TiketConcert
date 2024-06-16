using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Model
{
    public partial class Concert
    {
        public int IDConcert { get; set; }

        public string TitleConcert { get; set; }

        public DateTime StartDate { get; set; }

        public decimal DurationInHours { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string Poster { get; set; }

        public int InStock { get; set; }

        public int IDStyleOfMusic { get; set; }

        public int IDPlace { get; set; }

        public int IDOrganization { get; set; }

        public static implicit operator List<object>(Concert v)
        {
            throw new NotImplementedException();
        }
    }
}

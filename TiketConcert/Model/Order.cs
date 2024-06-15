using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Model
{
    public partial class Orderer
    {

        public DateTime DateOrder { get; set; }
        public int IDTicket { get; set; }
        public int Quantity { get; set; }
        public int IDConcert { get; set; }

        public string TitleConcert { get; set; }

        public DateTime StartDate { get; set; }

        public decimal DurationInHours { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string Poster { get; set; }

        public string InStock { get; set; }

        public decimal Total => Quantity * Price;
    }
}

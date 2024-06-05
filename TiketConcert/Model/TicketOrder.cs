using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Model
{
    public class TicketOrder
    {
        public int ticketId { get; set; }
        public int quantity { get; set; }
    }

    public class Order
    {
        public int IDClient { get; set; }
        public List<TicketOrder> tickets { get; set; }
    }
}

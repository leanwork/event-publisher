using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public class OrderSubmittedEvent
    {
        public string OrderId { get; set; }
    }
}

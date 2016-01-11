using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public class NotifyWarehouse : IConsumer<OrderSubmittedEvent>
    {
        public void Handle(OrderSubmittedEvent eventMessage)
        {
            //notify warehouse
            Debug.WriteLine("Warehouse notified: " + eventMessage.OrderId);
        }

        public Task HandleAsync(OrderSubmittedEvent eventMessage)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                //notify warehouse
                Debug.WriteLine("Warehouse notified: " + eventMessage.OrderId);
            });
        }
    }
}

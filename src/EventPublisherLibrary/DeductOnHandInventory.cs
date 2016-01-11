using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public class DeductOnHandInventory : IConsumer<OrderSubmittedEvent>
    {
        public void Handle(OrderSubmittedEvent eventMessage)
        {
            //deduct inventory
            Debug.WriteLine("Inventory deducted: " + eventMessage.OrderId);
        }

        public Task HandleAsync(OrderSubmittedEvent eventMessage)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
                //deduct inventory
                Debug.WriteLine("Inventory deducted: " + eventMessage.OrderId);
            });
        }
    }
}

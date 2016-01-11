using EventPublisherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //add event subscriptions
            EventSubscriptions.Add<EmailOrderConfirmation>();
            EventSubscriptions.Add<NotifyWarehouse>();
            EventSubscriptions.Add<DeductOnHandInventory>();

            //publish
            IEventPublisher eventPublisher = new EventPublisher(new EventSubscriptions());
            eventPublisher.PublishAsync<OrderSubmittedEvent>(new OrderSubmittedEvent { OrderId = Guid.NewGuid().ToString() });
            eventPublisher.PublishAsync<OrderSubmittedEvent>(new OrderSubmittedEvent { OrderId = Guid.NewGuid().ToString() });

            //Console.ReadKey();
        }
    }
}

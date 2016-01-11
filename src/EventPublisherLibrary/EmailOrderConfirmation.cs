using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public class EmailOrderConfirmation : IConsumer<OrderSubmittedEvent>
    {
        public void Handle(OrderSubmittedEvent eventMessage)
        {
            //send email
            Debug.WriteLine("Email sent: " + eventMessage.OrderId);
        }

        public Task HandleAsync(OrderSubmittedEvent eventMessage)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                //send email
                Debug.WriteLine("Email sent: " + eventMessage.OrderId);
            });
        }
    }
}

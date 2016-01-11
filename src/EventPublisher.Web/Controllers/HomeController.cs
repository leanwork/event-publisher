using EventPublisherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventPublisher.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            //add event subscriptions
            EventSubscriptions.Add<EmailOrderConfirmation>();
            EventSubscriptions.Add<NotifyWarehouse>();
            EventSubscriptions.Add<DeductOnHandInventory>();

            //publish
            IEventPublisher eventPublisher = new EventPublisherLibrary.EventPublisher(new EventSubscriptions());
            await eventPublisher.PublishAsync<OrderSubmittedEvent>(new OrderSubmittedEvent { OrderId = Guid.NewGuid().ToString() });
            await eventPublisher.PublishAsync<OrderSubmittedEvent>(new OrderSubmittedEvent { OrderId = Guid.NewGuid().ToString() });

            return Content("OK");
        }
    }
}
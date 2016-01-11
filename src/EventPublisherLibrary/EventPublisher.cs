using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ISubscriptionService _subscriptionService;

        public EventPublisher(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public void Publish<T>(T eventMessage)
        {
            var subscriptions = _subscriptionService.GetSubscriptions<T>();
            subscriptions.ToList().ForEach(x => PublishToConsumer(x, eventMessage));
        }

        public async Task PublishAsync<T>(T eventMessage)
        {
            var subscriptions = _subscriptionService.GetSubscriptions<T>();
            foreach (var item in subscriptions)
            {
                await PublishToConsumerAsync(item, eventMessage);
            }
        }

        private static void PublishToConsumer<T>(IConsumer<T> x, T eventMessage)
        {
            try
            {
                x.Handle(eventMessage);
            }
            catch (Exception e)
            {
                //log and handle internally
            }
            finally
            {
                var instance = x as IDisposable;
                if (instance != null)
                {
                    instance.Dispose();
                }
            }
        }

        private async Task PublishToConsumerAsync<T>(IConsumer<T> x, T eventMessage)
        {
            try
            {
                await x.HandleAsync(eventMessage);
            }
            catch (Exception e)
            {
                //log and handle internally
            }
            finally
            {
                var instance = x as IDisposable;
                if (instance != null)
                {
                    instance.Dispose();
                }
            }
        }
    }
}

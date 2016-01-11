using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace EventPublisherLibrary
{
    public class EventSubscriptions : ISubscriptionService
    {
        public static void Add<T>()
        {
            var consumerType = typeof(T);

            consumerType.GetInterfaces()
                        .Where(x => x.IsGenericType)
                        .Where(x => x.GetGenericTypeDefinition() == typeof(IConsumer<>))
                        .ToList()
                        .ForEach(x => IoC.Container.RegisterType(x,
                                                                 consumerType,
                                                                 consumerType.FullName));
        }

        public IEnumerable<IConsumer<T>> GetSubscriptions<T>()
        {
            var consumers = IoC.Container.ResolveAll(typeof(IConsumer<T>));
            return consumers.Cast<IConsumer<T>>();
        }
    }
}

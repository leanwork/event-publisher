using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventMessage);
        Task PublishAsync<T>(T eventMessage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherLibrary
{
    public interface IConsumer<T>
    {
        void Handle(T eventMessage);
        Task HandleAsync(T eventMessage);
    }
}

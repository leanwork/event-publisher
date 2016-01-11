using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPublisherLibrary
{
    public static class IoC
    {
        public static IUnityContainer Container
        {
            get { return _container ?? (_container = new UnityContainer()); }
        }
        static IUnityContainer _container;
    }
}
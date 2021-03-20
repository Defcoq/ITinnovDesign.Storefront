using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using StructureMap;

namespace ITinnovDesign.Storefront.Infrastructure.Domain.Events
{
    public class StructureMapDomainEventHandlerFactory : IDomainEventHandlerFactory
    {

        private readonly Container _container;

        public StructureMapDomainEventHandlerFactory(Container container)
        {
            _container = container;
        }

        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>
                                              (T domainEvent) where T : IDomainEvent
        {
          
           
            //return new List<IDomainEventHandler<T>>();
            return _container.GetAllInstances<IDomainEventHandler<T>>();
        }
    }

}

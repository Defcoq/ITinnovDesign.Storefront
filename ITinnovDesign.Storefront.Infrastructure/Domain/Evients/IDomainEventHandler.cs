using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Domain.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }

}

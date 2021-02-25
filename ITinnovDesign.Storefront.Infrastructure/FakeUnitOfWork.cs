using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }
    }
}

using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure
{
    public class FakeUnitOfWorkRepository : IUnitOfWorkRepository
    {
        public void PersistCreationOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }
    }
}

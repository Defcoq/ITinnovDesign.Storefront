using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        void Save(T entity);
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}

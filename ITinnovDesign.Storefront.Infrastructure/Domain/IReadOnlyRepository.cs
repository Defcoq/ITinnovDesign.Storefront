using ITinnovDesign.Storefront.Infrastructure.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
       // IQueryable<T> FindAll();
        IEnumerable<T> FindBy(Expression<Func<T, object>> query);
        IEnumerable<T> FindBy(Expression<Func<T, object>> query, int index, int count);
        IEnumerable<T> FindBy(IQueryable<T> query);
        IEnumerable<T> FindBy(IQueryable<T> query, int index, int count);

       // IEnumerable<T> FindBy(Query query);
       // IEnumerable<T> FindBy(Query qyery, int index, int count);
    }
}

using ITinnovDesign.Storefront.Infrastructure.Querying;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot 
    {

       // DbSet<TE> Table { get; }
       // NEWUTF_DEMO_DATIContext Context { get; }
        T FindBy(TId id);

        IQueryable<T> GetAll();
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
